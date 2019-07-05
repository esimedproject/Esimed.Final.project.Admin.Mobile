using System;
using System.Collections.Generic;
using System.Text;

namespace AppEmploye.View
{
    public interface IViewWithParameters
    {
        void InitializeWith(object parameter);
    }
}
