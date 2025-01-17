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

using System;
using System.Runtime.Serialization;

namespace Kyoo.Abstractions.Models.Exceptions
{
	/// <summary>
	/// An exception raised when an item already exists in the database.
	/// </summary>
	[Serializable]
	public class DuplicatedItemException : Exception
	{
		/// <summary>
		/// Create a new <see cref="DuplicatedItemException"/> with the default message.
		/// </summary>
		public DuplicatedItemException()
			: base("Already exists in the database.")
		{ }

		/// <summary>
		/// Create a new <see cref="DuplicatedItemException"/> with a custom message.
		/// </summary>
		/// <param name="message">The message to use</param>
		public DuplicatedItemException(string message)
			: base(message)
		{ }

		/// <summary>
		/// The serialization constructor.
		/// </summary>
		/// <param name="info">Serialization infos</param>
		/// <param name="context">The serialization context</param>
		protected DuplicatedItemException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{ }
	}
}
