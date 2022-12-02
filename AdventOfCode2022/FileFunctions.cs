// <copyright file="FileFunctions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AdventOfCode2022
{
    /// <summary>
    ///     The file functions.
    /// </summary>
    public class FileFunctions
    {

        public FileFunctions()
        {
        }
        
        /// <summary>
        ///     Gets or sets the file path.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public string FilePath { get; set; }

        /// <summary>
        ///     Gets or sets the config file info.
        /// </summary>
        public DateTime ConfigFileInfo { get; set; }

        /// <summary>
        ///     Gets or sets the watch file timer.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        // ReSharper disable once UnusedMember.Local
        private Timer WatchFileTimer { get; set; }

        /// <summary>
        ///     The file exists.
        /// </summary>
        /// <param name="filepath">
        ///     The file path.
        /// </param>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool FileExists(string filepath)
        {
            return File.Exists(filepath);
        }

        /// <summary>
        ///     The read file.
        /// </summary>
        /// <param name="filepath">
        ///     The file path.
        /// </param>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public async Task<string> ReadFile(string filepath)
        {
            try
            {
                return await File.ReadAllTextAsync(filepath);
            }
            catch (Exception e)
            {
                //_log.Error(e, "Unable to read file {Filepath}", filepath);
                throw;
            }
        }

        /// <summary>
        /// Get File Info.
        /// </summary>
        /// <param name="filepath">file path.</param>
        /// <returns>DateTime.</returns>
        public DateTime GetFileInfo(string filepath)
        {
            return File.GetCreationTime(filepath);
        }

        /// <summary>
        ///     The write file.
        /// </summary>
        /// <param name="filepath">
        ///     The file path.
        /// </param>
        /// <param name="data">
        ///     The data.
        /// </param>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public async Task<bool> WriteFile(string filepath, string data)
        {
            try
            {
                await File.WriteAllTextAsync(filepath, data);
                return true;
            }
            catch (Exception e)
            {
                //_log.Error(e, "Unable to Write File {Filepath}", filepath);
                return false;
            }
        }

        public bool DeleteFile(string filepath)
        {
            try
            {
                File.Delete(filepath);
                return true;
            }
            catch (Exception e)
            {
                //_log.Error(e, "Unable to Remove File {Filepath}", filepath);
                return false;
            }
        }
    }
}