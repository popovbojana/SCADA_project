using System.Collections;
using ScadaSnusProject.DTOs;
using ScadaSnusProject.Model;

namespace ScadaSnusProject.Services.Interfaces;

public interface IReportService
{
    public ICollection<TagValue> GetAllTagValuesForTag(int tagId, TimeSortReportDTO dto);
    public ICollection<TagValue> GetAllLastValuesForDigitalInputs(TimeSortReportDTO dto);
}