using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class StateTaxProductionRepository : IStateTaxRepository
    {
        public List<StateTax> StateTaxes()
        {
            string path = ConfigurationManager.AppSettings["tax"].ToString() + ".txt";
            string[] allLines = File.ReadAllLines(path);
            List<StateTax> stateTaxes = new List<StateTax>();

            for (int i = 1; i < allLines.Length; i++)
            {
                string[] columns = allLines[i].Split(',');

                StateTax st = new StateTax
                {
                    StateAbbreviation = columns[0],
                    StateName = columns[1],
                    TaxRate = decimal.Parse(columns[2])
                };

                stateTaxes.Add(st);
            }

            return stateTaxes;
        }
    }
}
