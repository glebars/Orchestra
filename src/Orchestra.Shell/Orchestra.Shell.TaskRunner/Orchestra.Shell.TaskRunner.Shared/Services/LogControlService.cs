﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogControlService.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2014 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orchestra.Services
{
    using Catel;
    using Catel.Logging;
    using Catel.Windows.Controls;
    using Catel.Windows.Threading;
    using Orc.Controls;

    public class LogControlService : ILogControlService
    {
        private readonly LogViewerControl _traceOutputControl;

        #region Constructors
        public LogControlService(LogViewerControl traceOutputControl)
        {
            Argument.IsNotNull(() => traceOutputControl);

            _traceOutputControl = traceOutputControl;
            _traceOutputControl.Dispatcher.BeginInvoke(() =>
            {
                _traceOutputControl.SetLogEvent(LogEvent.Info);
            });
        }
        #endregion

        public LogEvent SelectedLevel
        {
            get
            {
                return _traceOutputControl.GetLogEvent();
            }
            set
            {
                _traceOutputControl.SetLogEvent(value);
            }
        }

        public void Clear()
        {
            _traceOutputControl.Clear();
        }
    }
}