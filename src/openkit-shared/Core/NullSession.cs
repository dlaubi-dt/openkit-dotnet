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

using Dynatrace.OpenKit.API;

namespace Dynatrace.OpenKit.Core
{
    public class NullSession : ISession
    {
        private static readonly IRootAction NullRootAction = new NullRootAction();
        private static readonly IWebRequestTracer NullWebRequestTracer = new NullWebRequestTracer();

        public void Dispose()
        {
            End();
        }

        public void End()
        {
            // intentionally left empty, due to NullObject pattern
        }

        public IRootAction EnterAction(string actionName)
        {
            return NullRootAction;
        }

        public void IdentifyUser(string userTag)
        {
            // intentionally left empty, due to NullObject pattern
        }

        public void ReportCrash(string errorName, string reason, string stacktrace)
        {
            // intentionally left empty, due to NullObject pattern
        }

        public IWebRequestTracer TraceWebRequest(string url)
        {
            return NullWebRequestTracer;
        }
    }
}
