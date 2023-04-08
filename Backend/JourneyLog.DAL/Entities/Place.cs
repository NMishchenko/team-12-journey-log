using Azure.Core.Pipeline;
using Microsoft.VisualBasic.CompilerServices;

namespace JourneyLog.DAL.Entities;

public class Place
{
    public Guid Id { get; set; }
    public string Longtitude { get; set; }
    public string Latitude { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public string ImageLink { get; set; }
    public string Rate { get; set; }
    public string WikipediaLink { get; set; }
    
    public virtual ICollection<List> Lists { get; set; }
}