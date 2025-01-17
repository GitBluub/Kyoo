// Kyoo - A portable and vast media library solution.
// Copyright (c) Kyoo.
//
// See AUTHORS.md and LICENSE file in the project root for full license information.
//
// Kyoo is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// any later version.
//
// Kyoo is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Kyoo. If not, see <https://www.gnu.org/licenses/>.

using System.Collections.Generic;
using Kyoo.Abstractions.Models.Attributes;

namespace Kyoo.Abstractions.Models
{
	/// <summary>
	/// An actor, voice actor, writer, animator, somebody who worked on a <see cref="Show"/>.
	/// </summary>
	public class People : IResource, IMetadata, IThumbnails
	{
		/// <inheritdoc />
		public int ID { get; set; }

		/// <inheritdoc />
		public string Slug { get; set; }

		/// <summary>
		/// The name of this person.
		/// </summary>
		public string Name { get; set; }

		/// <inheritdoc />
		public Dictionary<int, string> Images { get; set; }

		/// <inheritdoc />
		[EditableRelation] [LoadableRelation] public ICollection<MetadataID> ExternalIDs { get; set; }

		/// <summary>
		/// The list of roles this person has played in. See <see cref="PeopleRole"/> for more information.
		/// </summary>
		[EditableRelation] [LoadableRelation] public ICollection<PeopleRole> Roles { get; set; }
	}
}
