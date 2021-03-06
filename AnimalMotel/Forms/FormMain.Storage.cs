using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AnimalMotel.Serialization;

namespace AnimalMotel
{
    /// <summary>
    ///   Partial class used to handle storage of data
    /// </summary>
    public partial class FormMain : Form
    {
        // Storage
        private string _pathToAnimalsFile = null;
        private string _pathToRecipesFile = null;
        private string _pathToPathsFolder = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\AppData\\FilePaths"));



        private void SaveAnimalsToFile(string filePath)
        {
            try
            {
                // Verify that .bin is used as file extension
                if (!filePath.EndsWith(".bin") ||
                    filePath[filePath.Length - 5].ToString().Equals("\\"))
                {
                    MessageBox.Show("Invalid file name. Must end with a \".bin\" file extension.");
                    return;
                }

                // Binary serialization
                BinarySerializerUtility.Serialize<List<Animal>>(filePath, this.AnimalManager.List);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private List<Animal> LoadAnimalsFromFile(string filePath)
        {
            List<Animal> animals = BinarySerializerUtility.Deserialize<List<Animal>>(filePath);
            return animals;
        }


        private string GetPathToAnimalsFile()
        {
            // Return previously used path if it exists
            if (!string.IsNullOrWhiteSpace(this._pathToAnimalsFile))
            {
                return this._pathToAnimalsFile;
            }

            // Create path if no previous path existed
            else
            {
                return this.SetPathToAnimalsFile();
            }
        }

        private string SetPathToAnimalsFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Name the file for Animals";
            saveFileDialog.Filter = "Binary Files | *.bin";     // Only recommend binary files for saving animals.

            var result = saveFileDialog.ShowDialog();

            // Return null if user cancels
            if (result == DialogResult.Cancel)
            {
                return null;
            }

            // If user provides file name
            else
            {
                // Check file length
                if (saveFileDialog.FileName.Length < 5)
                {
                    MessageBox.Show("You must provide a file name with a .bin extension");
                    return null;
                }

                string fileExtension = saveFileDialog.FileName.Substring(saveFileDialog.FileName.Length - 4);

                // Return null if extension is not .bin or if file name is less than 5 chars
                if (!fileExtension.Equals(".bin") ||
                    (saveFileDialog.FileName[saveFileDialog.FileName.Length - 5].Equals("\\")))
                {
                    MessageBox.Show("You must provide a file name with a .bin extension");
                    return null;
                }

                // Save path in App
                this._pathToAnimalsFile = saveFileDialog.FileName;

                /*
                 Save path in file for future reference
                 */

                // File that stores the path of the file that stores data about animals
                string animalsDataPathFile = $"{ this._pathToPathsFolder }\\PathsToAnimalsFile.txt";

                StreamWriter sr = new StreamWriter(this._pathToAnimalsFile);

                try
                {
                    sr.WriteLine(animalsDataPathFile);
                }
                catch
                {

                }
                finally
                {
                    sr.Close();
                }

                return saveFileDialog.FileName;
            }
        }

        private string GetPathToRecipesFile()
        {
            // Return previously used path if it exists
            if (!string.IsNullOrWhiteSpace(this._pathToRecipesFile))
            {
                return this._pathToRecipesFile;
            }

            // Create path if no previous path existed
            else
            {
                return this.SetPathToAnimalsFile();
            }
        }

        private string SetPathToRecipesFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Name the file for Recipes";
            saveFileDialog.Filter = "XML Files | *.xml";     // Only recommend xml files for saving recipes.

            var result = saveFileDialog.ShowDialog();

            // Return null if user cancels
            if (result == DialogResult.Cancel)
            {
                return null;
            }

            // If user provides file name
            else
            {
                // Check file length
                if (saveFileDialog.FileName.Length < 5)
                {
                    MessageBox.Show("You must provide a file name with a .xml extension");
                    return null;
                }

                string fileExtension = saveFileDialog.FileName.Substring(saveFileDialog.FileName.Length - 4);

                // Return null if extension is not .xml or if file name is less than 5 chars
                if (!fileExtension.Equals(".xml") ||
                    (saveFileDialog.FileName[saveFileDialog.FileName.Length - 5].Equals("\\")))
                {
                    MessageBox.Show("You must provide a file name with a .xml extension");
                    return null;
                }

                // Save path in App
                this._pathToAnimalsFile = saveFileDialog.FileName;

                /*
                 Save path in file for future reference
                 */

                // File that stores the path of the file that stores data about animals
                string recipesDataPathFile = $"{ this._pathToPathsFolder }\\PathsToRecipesFile.txt";

                StreamWriter sr = new StreamWriter(this._pathToRecipesFile);

                try
                {
                    sr.WriteLine(recipesDataPathFile);
                }
                catch
                {

                }
                finally
                {
                    sr.Close();
                }

                return saveFileDialog.FileName;
            }
        }


    }
}
