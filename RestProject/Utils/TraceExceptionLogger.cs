using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;
using Utils;

namespace RestProject.Utils
{
    public class TraceExceptionLogger : ExceptionLogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void Log(ExceptionLoggerContext context)
        {
            ExceptionExtras eh = new ExceptionExtras("Errore imprevisto");
            eh.AddParam("Uri", context.Request.RequestUri);
            eh.AddParam("Method", context.Request.Method.Method);
            log.Fatal(eh.ToString(), context.Exception);
        }
    }
}