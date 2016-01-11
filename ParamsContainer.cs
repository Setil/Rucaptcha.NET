﻿using System;
using System.Collections;

namespace Akumu.Antigate
{
  /// <summary>
  /// Объект коллекции дополнительных параметров API
  /// 
  /// </summary>
  public class ParamsContainer : ICloneable
  {
    private readonly Hashtable Params = new Hashtable();

    /// <summary>
    /// Возвращает кол-во параметров в коллекции
    /// 
    /// </summary>
    public int Count => Params.Count;

      /// <summary>
    /// Очистка списка параметров
    /// 
    /// </summary>
    public void Clear()
    {
      Params.Clear();
    }

    /// <summary>
    /// Возвращает копию списка
    /// 
    /// </summary>
    /// 
    /// <returns/>
    public object Clone()
    {
      var paramsContainer = new ParamsContainer();
      foreach (var index in (IEnumerable) Params.Keys)
      {
        var obj = (Param) Params[index];
        paramsContainer.Params.Add((object) obj.Key, (object) obj);
      }
      return (object) paramsContainer;
    }

    /// <summary>
    /// Добавляет или заменяет парметр в колекцию. Потоко-безопасен.
    /// 
    /// </summary>
    /// <param name="Key">Ключ</param><param name="Value">Значение</param>
    public void Set(string Key, string Value)
    {
      Set(new Param(Key, Value));
    }

    /// <summary>
    /// Добавляет или заменяет парметр в колекцию. Потоко-безопасен.
    /// 
    /// </summary>
    /// <param name="Param">Объект параметра</param>
    public void Set(Param Param)
    {
      if (Param.Key.Equals("soft_id", StringComparison.InvariantCultureIgnoreCase))
        return;
      lock (Params)
        Params[(object) Param.Key] = (object) Param;
    }

    /// <summary>
    /// Возвращает коллекцию параметров
    /// 
    /// </summary>
    /// 
    /// <returns/>
    public ICollection GetParams()
    {
      return Params.Values;
    }
  }
}
