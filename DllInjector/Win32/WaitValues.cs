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

namespace DllInjector.Win32
{
    /// <summary>
    /// Values that determine the wait status of an object (thread, mutex, event, etc.).
    /// </summary>
    public enum WaitValues : uint
    {
        /// <summary>
        /// The object is in a signaled state.
        /// </summary>
        WAIT_OBJECT_0 = 0x00000000,
        /// <summary>
        /// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread terminated. Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// </summary>
        WAIT_ABANDONED = 0x00000080,
        /// <summary>
        /// The time-out interval elapsed, and the object's state is nonsignaled.
        /// </summary>
        WAIT_TIMEOUT = 0x00000102,
        /// <summary>
        /// The wait has failed.
        /// </summary>
        WAIT_FAILED = 0xFFFFFFFF,
        /// <summary>
        /// Wait an infinite amount of time for the object to become signaled.
        /// </summary>
        INFINITE = 0xFFFFFFFF
    }
}
