using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_frame
{

  public class ToolObj
  {
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string property { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<string> input { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<string> output { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<ToolObj> children { get; set; }
  }

}
