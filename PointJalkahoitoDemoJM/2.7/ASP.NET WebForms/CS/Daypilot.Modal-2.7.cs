/*
Copyright © 2010 - 2017 Annpoint, s.r.o.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

-------------------------------------------------------------------------

NOTE: Reuse requires the following acknowledgement (see also NOTICE):
This product includes DayPilot (http://www.daypilot.org) developed by Annpoint, s.r.o.
*/

using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace Util
{

    /// <summary>
    /// Summary description for Modal
    /// </summary>
    public class Modal
    {

        public static void Close(Page page)
        {
            Close(page, null);
        }

        public static string Script(object result)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("if (parent && parent.DayPilot && parent.DayPilot.ModalStatic) {");
            sb.Append("parent.DayPilot.ModalStatic.close(" + new JavaScriptSerializer().Serialize(result) + ");");
            sb.Append("}");
            sb.Append("</script>");

            return sb.ToString();
        }

        public static void Close(Page page, object result)
        {
            page.ClientScript.RegisterStartupScript(typeof(Page), "close", Script(result));
            return;
        }

    }

}
