using System;
using System.Collections.Generic;
using System.Text;

namespace InteresCompuestoApp.Forms.Models.Mocks
{
    public class MockOperations
    {
        public static IEnumerable<Operation> GetOperationList()
        {
            return new List<Operation>
             {
                 new Operation { OperationName = "Monto"},
                 new Operation { OperationName = "Capital"},
                 new Operation { OperationName = "Interés"},
                 new Operation { OperationName = "Período"},
             };
        }
    }
}
