using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1_2
{
    class Relationship
    {
        public string connectionString { get; set; }
        public string masterName { get; set; }
        public string slaveName { get; set; }
        public string name { get; set; }
        public int attributes { get; set; }

        public string selectMaster { get; set; }
        public string selectSlave { get; set; }
        public string selectMaxId { get; set; }
        public string insertSlave { get; set; }
        public int insertSlaveParams { get; set; }
        public string updateSlave { get; set; }
        public int updateSlaveParams { get; set; }
        public string deleteSlave { get; set; }
        public int deleteSlaveParams { get; set; }

    }
}
