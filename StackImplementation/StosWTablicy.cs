using System;
using System.Collections;
using System.Collections.Generic;

namespace Stos
{
    public class StosWTablicy<T> : IStos<T>
    {
        private T[] tab;
        private int szczyt = -1;

        public StosWTablicy(int size = 10)
        {
            tab = new T[size];
            szczyt = -1;
        }

        public T Peek => IsEmpty ? throw new StosEmptyException() : tab[szczyt];

        public int Count => szczyt + 1;

        public bool IsEmpty => szczyt == -1;

        // dodatkowy iterator, udostępnia elementy stosu w porządku odwrotnym
        public IEnumerable<T> TopToBottom
        {
            get
            {
                for (int i = Count - 1; i >= 0; i--)
                {
                    yield return this[i];
                }
            }
        }

        public void Clear() => szczyt = -1;

        public T Pop()
        {
            if (IsEmpty)
                throw new StosEmptyException();

            szczyt--;
            return tab[szczyt + 1];
        }

        public void Push(T value)
        {
            if (szczyt == tab.Length - 1)
            {
                Array.Resize(ref tab, tab.Length * 2); // 2-krotne powiększanie się tablicy todo
            }

            szczyt++;
            tab[szczyt] = value;
        }

        public T this[int index] =>  
            (index > Count - 1) ?
                throw new IndexOutOfRangeException() :
                    tab[index];
        
        public void TrimExcess() //przycina stos, zostawiając 10% wolnego miejsca
        {
            int threshold = (int)(((double)tab.Length) * 0.9);
            int capacity = tab.Length;

            if((szczyt / capacity) < 0.9)
            {
                Array.Resize(ref tab, tab.Length - threshold);
            }
        }

        public T[] ToArray()
        {
            
            T[] temp = new T[szczyt + 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = tab[i];
            return temp;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<T> ToArrayReadOnly()
        {
            return Array.AsReadOnly(tab);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator() 
        {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }

        private class EnumeratorStosu : IEnumerator<T>
        {
            private readonly StosWTablicy<T> stos;
            private int position = -1;

            internal EnumeratorStosu(StosWTablicy<T> stos) => this.stos = stos;
            public T Current => stos.tab[position];
            object IEnumerator.Current => Current;

            public void Dispose() { } // nie wymaga implementacji
            public bool MoveNext()
            {
                if (position < stos.Count - 1)
                {
                    position++;
                    return true;
                }
                else
                    return false;
            }
            public void Reset() => position = -1;
        }
    }

}
