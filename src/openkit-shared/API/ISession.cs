﻿//
// Copyright 2018-2019 Dynatrace LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;

namespace Dynatrace.OpenKit.API
{

    /// <summary>
    ///  This interface provides functionality to create Actions in a Session.
    /// </summary>
    public interface ISession : IDisposable
    {

        /// <summary>
        ///  Enters an Action with a specified name in this Session.
        /// </summary>
        /// <remarks>
        /// If <paramref name="actionName"/> is <code>null</code> or an empty string,
        /// a <see cref="NullAction"/> is entered and therefore no action tracing happens.
        /// </remarks>
        /// <param name="actionName">name of the Action</param>
        /// <returns>Action instance to work with</returns>
        IRootAction EnterAction(string actionName);

        /// <summary>
        ///  Tags a session with the provided <code>userTag</code>
        /// </summary>
        /// <remarks>
        /// If <paramref name="userTag"/> is <code>null</code> or an empty string,
        /// no user identification is sent to the server.
        /// </remarks>
        /// <param name="userTag"></param>
        void IdentifyUser(string userTag);

        /// <summary>
        ///  Reports a crash with a specified error name, crash reason and a stacktrace.
        /// </summary>
        /// <param name="errorName">name of the error leading to the crash (e.g. Exception class)</param>
        /// <param name="reason">reason or description of that error</param>
        /// <param name="stacktrace">stacktrace leading to that crash</param>
        void ReportCrash(string errorName, string reason, string stacktrace);

        /// <summary>
        ///  Allows tracing and timing of a web request handled by any 3rd party HTTP Client (e.g. Apache, Google, ...).
        ///  In this case the Dynatrace HTTP header (<see cref="OpenKitConstants.WEBREQUEST_TAG_HEADER"/>) has to be set manually to the
        ///  traces value of this WebRequestTracer.
        ///  If the web request is continued on a server-side Agent (e.g. Java, .NET, ...) this Session will be correlated to
        ///  the resulting server-side PurePath.
        /// </summary>
        /// <remarks>
        /// If given <paramref name="url"/> is <code>null</code> or an empty string, then
        /// a <see cref="NullWebRequestTracer"/> is returned and nothing is reported to the server.
        /// </remarks>
        /// <param name="url">the URL of the web request to be traced and timed</param>
        /// <returns>a WebRequestTracer which allows getting the tag value and adding timing information</returns>
        IWebRequestTracer TraceWebRequest(string url);

        /// <summary>
        ///  Ends this Session and marks it as ready for immediate sending.
        /// </summary>
        void End();
    }

}
