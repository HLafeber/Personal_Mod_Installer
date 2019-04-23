using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaberModManager.Core
{
    public class BuildInfo
    {
        public string Name { get; set; }

        public string FullName
        {
            get
            {
                return "Microsoft " + Name + " " + "[Version " + Major + "." + Minor + "." + Build + "]";
            }
        }

        public int Minor { get; set; }

        public int Major { get; set; }

        public int Build { get; set; }

        private BuildInfo() { }

        /// <summary> 
        /// Init OSVersionInfo object by current windows environment 
        /// </summary> 
        /// <returns></returns> 
        public static BuildInfo GetBuildInfo()
        {
            System.OperatingSystem osVersionObj = System.Environment.OSVersion;

            BuildInfo osVersionInfo = new BuildInfo()
            {
                Name = GetOSName(osVersionObj),
                Major = osVersionObj.Version.Major,
                Minor = osVersionObj.Version.Minor,
                Build = osVersionObj.Version.Build
            };

            return osVersionInfo;
        }

        /// <summary> 
        /// Get current windows name 
        /// </summary> 
        /// <param name="osInfo"></param> 
        /// <returns></returns> 
        static string GetOSName(System.OperatingSystem osInfo)
        {
            string osName = "unknown";

            switch (osInfo.Platform)
            {
                //for old windows kernel 
                case System.PlatformID.Win32Windows:
                    osName = ForWin32Windows(osInfo);
                    break;
                //fow NT kernel 
                case System.PlatformID.Win32NT:
                    osName = ForWin32NT(osInfo);
                    break;
            }

            return osName;
        }

        /// <summary>
        /// Get the current windows 10 build
        /// </summary>
        /// <returns></returns>
        static Build GetBuildVersion()
        {
            System.OperatingSystem osVersionObj = System.Environment.OSVersion;
            switch (osVersionObj.Version.Build)
            {
                case 1507:
                    return Core.Build.Threshold1;
                case 10586:
                    return Core.Build.Threshold2;
                case 14393:
                    return Core.Build.Anniversary;
                case 16299:
                    return Core.Build.October2018;
                default:
                    return Core.Build.Unknown;
                
            }
        }

        /// <summary> 
        /// for old windows kernel 
        /// this function is the child function for method GetOSName 
        /// </summary> 
        /// <param name="osInfo"></param> 
        /// <returns></returns> 
        static string ForWin32Windows(System.OperatingSystem osInfo)
        {
            string osVersion = "Unknown";

            //Code to determine specific version of Windows 95,  
            //Windows 98, Windows 98 Second Edition, or Windows Me. 
            switch (osInfo.Version.Minor)
            {
                case 0:
                    osVersion = "Windows 95";
                    break;
                case 10:
                    switch (osInfo.Version.Revision.ToString())
                    {
                        case "2222A":
                            osVersion = "Windows 98 Second Edition";
                            break;
                        default:
                            osVersion = "Windows 98";
                            break;
                    }
                    break;
                case 90:
                    osVersion = "Windows Me";
                    break;
            }

            return osVersion;
        }

        /// <summary> 
        /// fow NT kernel 
        /// this function is the child function for method GetOSName 
        /// </summary> 
        /// <param name="osInfo"></param> 
        /// <returns></returns> 
        static string ForWin32NT(System.OperatingSystem osInfo)
        {
            string osVersion = "Unknown";

            //Code to determine specific version of Windows NT 3.51,  
            //Windows NT 4.0, Windows 2000, or Windows XP. 
            switch (osInfo.Version.Major)
            {
                case 3:
                    osVersion = "Windows NT 3.51";
                    break;
                case 4:
                    osVersion = "Windows NT 4.0";
                    break;
                case 5:
                    switch (osInfo.Version.Minor)
                    {
                        case 0:
                            osVersion = "Windows 2000";
                            break;
                        case 1:
                            osVersion = "Windows XP";
                            break;
                        case 2:
                            osVersion = "Windows 2003";
                            break;
                    }
                    break;
                case 6:
                    switch (osInfo.Version.Minor)
                    {
                        case 0:
                            osVersion = "Windows Vista";
                            break;
                        case 1:
                            osVersion = "Windows 7";
                            break;
                        case 2:
                            osVersion = "Windows 8";
                            break;
                        case 3:
                            osVersion = "Windows 8.1";
                            break;
                    }
                    break;
                case 10:
                    osVersion = "Windows 10";
                    break;
            }

            return osVersion;
        }
    }

    public enum Build
    {
        Unknown = 0,         // <- Disable Areo completely.
        Threshold1 = 1507,   // 10240 Treshold 1 <- Use old Areo above this version
        Threshold2 = 1511,   // 10586 Treshold 2
        Anniversary = 1607,  // 14393 Redstone 1
        Creators = 1703,     // 15063 Redstone 2
        FallCreators = 1709, // 16299 Redstone 3 <-Use new Areo above this version.
        April2018 = 1803,    // 17134 Redstone 4
        October2018 = 1809,  // 17763 Redstone 5
        May2019 = 1903       // 18362 19H1
                             // 18875 20H1
    }
}
