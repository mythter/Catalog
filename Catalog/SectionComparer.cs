using System.Diagnostics.CodeAnalysis;

namespace BookCatalog
{
    class SectionComparer : IEqualityComparer<Section>
    {
        public bool Equals(Section? s1, Section? s2)
        {
            if (s1 is null)
            {
                throw new ArgumentNullException(nameof(s1));
            }

            if (s2 is null)
            {
                throw new ArgumentNullException(nameof(s2));
            }

            if (s1.Name == s2.Name)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode([DisallowNull] Section obj)
        {
            return obj.GetHashCode();
        }
    }
}
