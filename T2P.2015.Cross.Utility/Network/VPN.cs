﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace T2P._2015.Cross.Utility.Network
{
    public class VPN
    {
        public static bool MapDrive(string drive, string folderShare)
        {
            NetworkDrive netDrive = null;
            try
            {
                netDrive = new Network.NetworkDrive();
                netDrive.LocalDrive = drive;
                netDrive.ShareName = folderShare;
                netDrive.MapDrive();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                netDrive = null;
            }
        }

        public static bool MapDrive(string drive, string folderShare, string userName, string password)
        {
            NetworkDrive netDrive = null;
            try
            {
                if (Directory.Exists(drive))
                {
                    return true;
                }
                else
                {
                    netDrive = new Network.NetworkDrive();
                    netDrive.LocalDrive = drive;
                    netDrive.ShareName = folderShare;
                    netDrive.MapDrive(userName, password);
                    return true;
                }
            }
            catch (Exception ex)
            {
                T2P._2015.Cross.Utility.ExceptionHandling.ExceptionHelper.GetDetailMessageAndLog(ex);
                return false;
            }
            finally
            {
                netDrive = null;
            }
        }

        public static bool MapDrive(string drive, string folderShare, string workingFolder, string userName, string password)
        {
            NetworkDrive netDrive = null;
            try
            {
                if (Directory.Exists(drive))
                {
                    return true;
                }
                else
                {
                    netDrive = new Network.NetworkDrive();
                    netDrive.LocalDrive = drive;
                    netDrive.ShareName = folderShare;
                    netDrive.MapDrive(userName, password);

                    if (Directory.Exists(workingFolder))
                        return true;
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                netDrive = null;
            }
        }

        public static bool UnmapDrive(string Drive)
        {
            //NetworkDrive netDrive = null;
            try
            {
                //if (Directory.Exists(Drive))
                //{
                //    System.Diagnostics.ProcessStartInfo PInfo;
                //    System.Diagnostics.Process P;
                //    PInfo = new System.Diagnostics.ProcessStartInfo("cmd", @"/c net use " + Drive + " /delete");
                //    PInfo.CreateNoWindow = true; //nowindow
                //    PInfo.UseShellExecute = true; //use shell
                //    P = System.Diagnostics.Process.Start(PInfo);
                //    //P.WaitForExit(1000); //give it some time to finish
                //    P.Close();
                //}
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                //netDrive = null;
            }
        }
    }

    public class NetworkDrive
    {
        #region API

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2A(ref structNetResource pstNetRes, string psPassword, string psUsername, int piFlags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2A(string psName, int piFlags, int pfForce);

        [DllImport("mpr.dll")]
        private static extern int WNetConnectionDialog(int phWnd, int piType);

        [DllImport("mpr.dll")]
        private static extern int WNetDisconnectDialog(int phWnd, int piType);

        [DllImport("mpr.dll")]
        private static extern int WNetRestoreConnectionW(int phWnd, string psLocalDrive);

        [StructLayout(LayoutKind.Sequential)]
        private struct structNetResource
        {
            public int iScope;
            public int iType;
            public int iDisplayType;
            public int iUsage;
            public string sLocalName;
            public string sRemoteName;
            public string sComment;
            public string sProvider;
        }

        private const int RESOURCETYPE_DISK = 0x1;

        //Standard
        private const int CONNECT_INTERACTIVE = 0x00000008;

        private const int CONNECT_PROMPT = 0x00000010;
        private const int CONNECT_UPDATE_PROFILE = 0x00000001;

        //IE4+
        private const int CONNECT_REDIRECT = 0x00000080;

        //NT5 only
        private const int CONNECT_COMMANDLINE = 0x00000800;

        private const int CONNECT_CMD_SAVECRED = 0x00001000;

        #endregion API

        #region Propertys and options

        private bool lf_SaveCredentials = false;

        /// <summary>
        /// Option to save credentials are reconnection...
        /// </summary>
        public bool SaveCredentials
        {
            get { return (lf_SaveCredentials); }
            set { lf_SaveCredentials = value; }
        }

        private bool lf_Persistent = false;

        /// <summary>
        /// Option to reconnect drive after log off / reboot ...
        /// </summary>
        public bool Persistent
        {
            get { return (lf_Persistent); }
            set { lf_Persistent = value; }
        }

        private bool lf_Force = false;

        /// <summary>
        /// Option to force connection if drive is already mapped...
        /// or force disconnection if network path is not responding...
        /// </summary>
        public bool Force
        {
            get { return (lf_Force); }
            set { lf_Force = value; }
        }

        private bool ls_PromptForCredentials = false;

        /// <summary>
        /// Option to prompt for user credintals when mapping a drive
        /// </summary>
        public bool PromptForCredentials
        {
            get { return (ls_PromptForCredentials); }
            set { ls_PromptForCredentials = value; }
        }

        private string ls_Drive = "s:";

        /// <summary>
        /// Drive to be used in mapping / unmapping...
        /// </summary>
        public string LocalDrive
        {
            get { return (ls_Drive); }
            set
            {
                if (value.Length >= 1)
                {
                    ls_Drive = value.Substring(0, 1) + ":";
                }
                else
                {
                    ls_Drive = "";
                }
            }
        }

        private string ls_ShareName = "\\\\Computer\\C$";

        /// <summary>
        /// Share address to map drive to.
        /// </summary>
        public string ShareName
        {
            get { return (ls_ShareName); }
            set { ls_ShareName = value; }
        }

        #endregion Propertys and options

        #region Function mapping

        /// <summary>
        /// Map network drive
        /// </summary>
        public void MapDrive()
        {
            mapDrive(null, null);
        }

        /// <summary>
        /// Map network drive (using supplied Password)
        /// </summary>
        public void MapDrive(string Password)
        {
            mapDrive(null, Password);
        }

        /// <summary>
        /// Map network drive (using supplied Username and Password)
        /// </summary>
        public void MapDrive(string Username, string Password)
        {
            mapDrive(Username, Password);
        }

        /// <summary>
        /// Unmap network drive
        /// </summary>
        public void UnMapDrive()
        {
            unMapDrive(this.lf_Force);
        }

        /// <summary>
        /// Check / restore persistent network drive
        /// </summary>
        public void RestoreDrives()
        {
            restoreDrive();
        }

        #endregion Function mapping

        #region Core functions

        // Map network drive
        private void mapDrive(string psUsername, string psPassword)
        {
            //create struct data
            structNetResource stNetRes = new structNetResource();
            stNetRes.iScope = 2;
            stNetRes.iType = RESOURCETYPE_DISK;
            stNetRes.iDisplayType = 3;
            stNetRes.iUsage = 1;
            stNetRes.sRemoteName = ls_ShareName;
            stNetRes.sLocalName = ls_Drive;
            //prepare params
            int iFlags = 0;
            if (lf_SaveCredentials) { iFlags += CONNECT_CMD_SAVECRED; }
            if (lf_Persistent) { iFlags += CONNECT_UPDATE_PROFILE; }
            if (ls_PromptForCredentials) { iFlags += CONNECT_INTERACTIVE + CONNECT_PROMPT; }
            if (psUsername == "") { psUsername = null; }
            if (psPassword == "") { psPassword = null; }
            //if force, unmap ready for new connection
            if (lf_Force) { try { unMapDrive(true); } catch { } }
            //call and return
            int i = WNetAddConnection2A(ref stNetRes, psPassword, psUsername, iFlags);
            if (i > 0) { throw new System.ComponentModel.Win32Exception(i); }
        }

        // Unmap network drive
        private void unMapDrive(bool pfForce)
        {
            //call unmap and return
            int iFlags = 0;
            if (lf_Persistent) { iFlags += CONNECT_UPDATE_PROFILE; }
            int i = WNetCancelConnection2A(ls_Drive, iFlags, Convert.ToInt32(pfForce));
            if (i != 0) i = WNetCancelConnection2A(ls_ShareName, iFlags, Convert.ToInt32(pfForce));  //disconnect if localname was null
            if (i > 0) { throw new System.ComponentModel.Win32Exception(i); }
        }

        // Check / Restore a network drive
        private void restoreDrive()
        {
            //call restore and return
            int i = WNetRestoreConnectionW(0, null);
            if (i > 0) { throw new System.ComponentModel.Win32Exception(i); }
        }

        #endregion Core functions
    }
}