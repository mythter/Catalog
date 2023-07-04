using System.Diagnostics.CodeAnalysis;

namespace BookCatalog
{
    internal class ElementComparer : IEqualityComparer<Element>
    {
        public bool Equals(Element? e1, Element? e2)
        {
            if (e1 is null)
            {
                throw new ArgumentNullException(nameof(e1));
            }

            if (e2 is null)
            {
                throw new ArgumentNullException(nameof(e2));
            }

            if (e1.Name == e2.Name)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode([DisallowNull] Element obj)
        {
            return obj.GetHashCode();
        }
    }
}
