using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANEJO_DATOS
{
    public class SomeResource : IDisposable
    {
        private bool isDisposed = false;

        // Constructor
        public SomeResource()
        {
            Console.WriteLine("SomeResource ha sido inicializado.");
        }

        // Método ficticio que realiza algún trabajo
        public void DoWork()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("SomeResource", "El recurso ha sido liberado y no puede utilizarse.");
            }
            Console.WriteLine("SomeResource está haciendo algún trabajo.");
        }

        // Implementación de IDisposable para liberar recursos
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    //if (managedResource != null)
                    //{
                    //    managedResource.Dispose();
                    //    managedResource = null;
                    //}
                }

                // Liberar recursos no administrados aquí (si los hubiera)

                isDisposed = true;
            }
        }

        // Destructor (finalizador) para liberar recursos no administrados (si los hubiera)
        ~SomeResource()
        {
            Dispose(false);
        }
    }
}
