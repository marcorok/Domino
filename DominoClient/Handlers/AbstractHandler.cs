﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithGraphicsFramework.Handlers
{
    internal abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public virtual object Handle(object request) {
            if (_nextHandler != null) { 
                return _nextHandler;
            }
            else
            {
                return null;
            }
        }

        public IHandler SetNext(IHandler next)
        {
            _nextHandler = next;
            return next;
        }


    }
}
