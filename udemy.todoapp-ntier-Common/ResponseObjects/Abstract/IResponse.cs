using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_Common.ResponseObjects.Concrete;

namespace udemy.todoapp_ntier_Common.ResponseObjects.Abstract
{
    public interface IResponse
    {
        string Message { get; set; }
        ResponseType ResponseType { get; set; }
    }
}
