using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1.Droid
{
  interface Iterator
  {
    Boolean hasNext();
    FietsTrommel next();
  }

  interface Container
  {
    Iterator getIterator();
  }

  class MarkerFactory : Container
  {
    private List<FietsTrommel> elements;

    public MarkerFactory(List<FietsTrommel> elements)
    {
      this.elements = elements;
    }

    public Iterator getIterator()
    {
      return new IteratorC(this.elements);
    }

    private class IteratorC : Iterator
    {
      private List<FietsTrommel> elements;
      public IteratorC(List<FietsTrommel> elements)
      {
        this.elements = elements;
      }
      private int index;
      public bool hasNext()
      {
        if (this.index < this.elements.Count)
        {
          return true;
        }
        return false;
      }

      public FietsTrommel next()
      {
        if (this.hasNext())
        {
          return elements[index++];
        }
        return null;
      }
    }
  }
}