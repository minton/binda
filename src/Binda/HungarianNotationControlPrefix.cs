using System;

namespace Binda
{
    /// <summary>
    /// Filters out lowercase prefixes. i.e., txtMyName would be returned as MyName
    /// </summary>
    public class HungarianNotationControlPrefix : ControlPrefix
    {
        public override string RemovePrefix(string name)
        {
            var start = FindFirstUpperCharacter(name);
            return name.Substring(start);
        }

        static int FindFirstUpperCharacter(string name)
        {
            for (var i = 0; i < name.Length; i++)
            {
                if (Char.IsUpper(name[i])) return i;
            }
            return 0;
        }
    }
}