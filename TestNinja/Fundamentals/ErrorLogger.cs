
using System;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged;

        private Guid _errorId;

        public void Log(string error)
        {
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            //LastError = error; 

            // Write the log to a storage
            // ...

            //ErrorLogged?.Invoke(this, Guid.NewGuid());
            //OnErrorLogged(Guid.NewGuid());
            //_errorId = new Guid();
            OnErrorLogged(Guid.NewGuid());
            //ErrorLogged?.Invoke(this, _errorId);
        }

        //implementation detail (not write tests for this)
        //public virtual void OnErrorLogged()
        //{
        //    ErrorLogged?.Invoke(this, _errorId);
        //}

        protected virtual void OnErrorLogged(Guid errorId)
        {
            ErrorLogged?.Invoke(this, errorId);
        }
    }
}