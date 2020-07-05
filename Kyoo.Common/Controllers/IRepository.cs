using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Kyoo.Models;

namespace Kyoo.Controllers
{
	public readonly struct Pagination
	{
		public int Count { get; }
		public int AfterID { get; }

		public Pagination(int count, int afterID = 0)
		{
			Count = count;
			AfterID = afterID;
		}
	}

	public readonly struct Sort<T>
	{
		public Expression<Func<T, object>> Key { get; }
		public bool Descendant { get; }
		
		public Sort(Expression<Func<T, object>> key, bool descendant = false)
		{
			Key = key;
			Descendant = descendant;
			
			if (!(Key.Body is MemberExpression))
				throw new ArgumentException("The given sort key is not valid.");
		}

		public Sort(string sortBy)
		{
			if (string.IsNullOrEmpty(sortBy))
			{
				Key = null;
				Descendant = false;
				return;
			}
			
			string key = sortBy.Contains(':') ? sortBy.Substring(0, sortBy.IndexOf(':')) : sortBy;
			string order = sortBy.Contains(':') ? sortBy.Substring(sortBy.IndexOf(':') + 1) : null;
			
			Key = Expression.Lambda<Func<T, object>>(Expression.Property(Expression.Parameter(typeof(T), "x"), key));
			Descendant = order switch
			{
				"desc" => true,
				"asc" => false,
				_ => throw new ArgumentException($"The sort order, if set, should be :asc or :desc but it was :{order}.")
			};
		}
	}
	
	public interface IRepository<T> : IDisposable, IAsyncDisposable
	{
		Task<T> Get(int id);
		Task<T> Get(string slug);
		Task<ICollection<T>> Search(string query);
		
		Task<ICollection<T>> GetAll(Expression<Func<T, bool>> where = null, 
			Sort<T> sort = default,
			Pagination page = default);

		Task<ICollection<T>> GetAll([Optional] Expression<Func<T, bool>> where,
			Expression<Func<T, object>> sort,
			Pagination page = default
		) => GetAll(where, new Sort<T>(sort), page);
		
		Task<int> Create([NotNull] T obj);
		Task<int> CreateIfNotExists([NotNull] T obj);
		Task Edit([NotNull] T edited, bool resetOld);
		
		Task Delete(int id);
		Task Delete(string slug);
		Task Delete([NotNull] T obj);

		Task DeleteRange(params T[] objs) => DeleteRange(objs.AsEnumerable());
		Task DeleteRange(IEnumerable<T> objs);
		Task DeleteRange(params int[] ids) => DeleteRange(ids.AsEnumerable());
		Task DeleteRange(IEnumerable<int> ids);
		Task DeleteRange(params string[] slugs) => DeleteRange(slugs.AsEnumerable());
		Task DeleteRange(IEnumerable<string> slugs);
	}

	public interface IShowRepository : IRepository<Show>
	{
		Task<Show> GetByPath(string path);
		Task AddShowLink(int showID, int? libraryID, int? collectionID);
	}

	public interface ISeasonRepository : IRepository<Season>
	{
		Task<Season> Get(string showSlug, int seasonNumber);
		Task Delete(string showSlug, int seasonNumber);
		
		Task<ICollection<Season>> GetSeasons(int showID);
		Task<ICollection<Season>> GetSeasons(string showSlug);
	}
	
	public interface IEpisodeRepository : IRepository<Episode>
	{
		Task<Episode> Get(string showSlug, int seasonNumber, int episodeNumber);
		Task Delete(string showSlug, int seasonNumber, int episodeNumber);
		
		Task<ICollection<Episode>> GetEpisodes(int showID, int seasonNumber);
		Task<ICollection<Episode>> GetEpisodes(string showSlug, int seasonNumber);
		Task<ICollection<Episode>> GetEpisodes(int seasonID);
	}

	public interface ITrackRepository : IRepository<Track>
	{
		Task<Track> Get(int episodeID, string languageTag, bool isForced);
	}
	public interface ILibraryRepository : IRepository<Library> {}
	public interface ICollectionRepository : IRepository<Collection> {}
	public interface IGenreRepository : IRepository<Genre> {}
	public interface IStudioRepository : IRepository<Studio> {}
	public interface IPeopleRepository : IRepository<People> {}
	public interface IProviderRepository : IRepository<ProviderID> {}
}