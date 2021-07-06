using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace MetroFramework.Fonts
{
    public class FontResolver : MetroFonts.IMetroFontResolver
    {
        private const string OPEN_SANS_REGULAR = "Open Sans";
        private const string OPEN_SANS_LIGHT = "Open Sans Light";
        private const string OPEN_SANS_BOLD = "Open Sans Bold";

        public Font ResolveFont(string familyName, float emSize, FontStyle fontStyle, GraphicsUnit unit)
        {
            CultureInfo oldCulture = Thread.CurrentThread.CurrentUICulture;
            try
            {
                Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");

                Font fontTester = new Font(familyName, emSize, fontStyle, unit);
                if (fontTester.Name == familyName || !TryResolve(ref familyName, ref fontStyle))
                {
                    return fontTester;
                }
                fontTester.Dispose();

                FontFamily fontFamily = GetFontFamily(familyName);
                return new Font(fontFamily, emSize, fontStyle, unit);
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = oldCulture;
            }
        }

        private readonly PrivateFontCollection fontCollection = new PrivateFontCollection();

        private static bool TryResolve(ref string familyName, ref FontStyle fontStyle)
        {
            if (familyName == "Malgun Gothic Semilight")
            {
                familyName = OPEN_SANS_LIGHT;
                if( fontStyle != FontStyle.Bold) fontStyle = FontStyle.Regular;
                return true;
            }

            if (familyName == "Malgun Gothic")
            {
                if (fontStyle == FontStyle.Bold)
                {
                    familyName = OPEN_SANS_BOLD;
                    return true;
                }

                familyName = OPEN_SANS_REGULAR;
                return true;
            }

            return false;
        }

        private FontFamily GetFontFamily(string familyName)
        {
            lock (fontCollection)
            {
                foreach (FontFamily fontFamily in fontCollection.Families)
                    if (fontFamily.Name == familyName) return fontFamily;

                string resourceName = GetType().Namespace + ".Resources." + familyName.Replace(' ', '_') + ".ttf";

                Stream fontStream = null;
                IntPtr data = IntPtr.Zero;
                try
                {
                    fontStream = GetType().Assembly.GetManifestResourceStream(resourceName);
                    int bytes = (int)fontStream.Length;
                    data = Marshal.AllocCoTaskMem(bytes);
                    byte[] fontdata = new byte[bytes];
                    fontStream.Read(fontdata, 0, bytes);
                    Marshal.Copy(fontdata, 0, data, bytes);
                    fontCollection.AddMemoryFont(data, bytes);
                    return fontCollection.Families[fontCollection.Families.Length - 1];
                }
                finally
                {
                    if (fontStream != null) fontStream.Dispose();
                    if (data != IntPtr.Zero) Marshal.FreeCoTaskMem(data);
                }
            }
        }
    }
}
