﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Autofac.Logging;
using Core.CrossCuttingConcerns.Autofac.Logging.Log4Net;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;

namespace Core.Aspects.Autofac.Logging
{
    class LogAspect:MethodInterception
    {
        private LoggerServiceBase _loggerService;

        public LogAspect(Type loggerService)
        {
            if (loggerService!=typeof(LoggerServiceBase))
            {
                throw new System.Exception("Wrong logger type");

                this._loggerService = (LoggerServiceBase)Activator.CreateInstance(loggerService);
            }

        }
        protected override void OnBefore(IInvocation invocation)
        {
            this._loggerService.Info(GetLogDetail(invocation));
        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                { 
                    Name=invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Type= invocation.Arguments[i].GetType().Name,
                    Value= invocation.Arguments[i]
                });
            }

            var logDetail = new LogDetail
            {
                LogParameters = logParameters,
                MethodName =invocation.Method.Name
            };

            return logDetail;

        }
    }
}
