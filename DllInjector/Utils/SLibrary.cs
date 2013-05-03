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
using DllInjector.Win32;

namespace DllInjector.Utils
{
    public static class SLibrary
    {
        /// <summary>
        /// Loads the specified module into the address space of the calling process.
        /// </summary>
        /// <param name="filename">The name of the module.</param>
        /// <returns>Returns handle to the</returns>
        public static IntPtr LoadLibrary(string filename)
        {
            IntPtr loadedLibraryHandle = Imports.LoadLibrary(filename);
            if (loadedLibraryHandle == IntPtr.Zero)
            {
                throw new Exception("LoadLibrary failed.");
            }
            return loadedLibraryHandle;
        }
    }
}
