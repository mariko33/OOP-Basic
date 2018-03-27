
using System.Collections.Generic;

public interface ILeutenantGeneral:ISoldier
{
    List<IPrivate> Privates { get; }
}
