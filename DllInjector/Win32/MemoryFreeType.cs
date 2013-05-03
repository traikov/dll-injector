// Dll Injector
// Copyright (C) 2013 Filip Traikov
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DllInjector.Win32
{
    /// <summary>
    /// Values that determine how a block of memory is freed.
    /// </summary>
    [Flags]
    public enum MemoryFreeType : uint
    {
        /// <summary>
        /// Decommits the specified region of committed pages. After the operation, the pages are in the reserved state.
        ///
        ///The function does not fail if you attempt to decommit an uncommitted page. This means that you can decommit a range of pages without first determining their current commitment state.
        ///
        ///Do not use this value with MEM_RELEASE.
        /// </summary>
        MEM_DECOMMIT = 0x4000,

        /// <summary>
        /// Releases the specified region of pages. After the operation, the pages are in the free state.
        ///
        /// If you specify this value, dwSize must be 0 (zero), and lpAddress must point to the base address returned by the VirtualAllocEx function when the region is reserved. The function fails if either of these conditions is not met.
        ///
        /// If any pages in the region are committed currently, the function first decommits, and then releases them.
        ///
        /// The function does not fail if you attempt to release pages that are in different states, some reserved and some committed. This means that you can release a range of pages without first determining the current commitment state.
        ///
        /// Do not use this value with MEM_DECOMMIT.
        /// </summary>
        MEM_RELEASE = 0x8000
    }
}
