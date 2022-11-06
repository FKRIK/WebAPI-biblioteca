using System;

namespace WebAPI_biblioteca.Handlers
{
    public interface IHandler<TRequest, TResult>
    {
        public IHandler<TRequest, TResult> Next { get; set; }
        public TResult Handle(TRequest request);
    }
}