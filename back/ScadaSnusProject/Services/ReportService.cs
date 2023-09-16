using System.Globalization;
using ScadaSnusProject.DTOs;
using ScadaSnusProject.Model;
using ScadaSnusProject.Repositories.Interfaces;
using ScadaSnusProject.Services.Interfaces;

namespace ScadaSnusProject.Services;

public class ReportService : IReportService
{
    private readonly ITagRepository _tagRepository;
    private readonly IAlarmRepository _alarmRepository;

    public ReportService(ITagRepository tagRepository, IAlarmRepository alarmRepository)
    {
        _tagRepository = tagRepository;
        _alarmRepository = alarmRepository;
    }

    public ICollection<TagValue> GetAllTagValuesForTag(int tagId, TimeSortReportDTO dto)
    {
        // ICollection<TagValue> allTagValues = _tagRepository.GetAllTagValuesForTag(tagId);
        // if (dto.TimeSort == TimeSort.Desc)
        // {
        //     List<TagValue> sortedDescTagValues = allTagValues.OrderByDescending(tv => DateTime.ParseExact(tv.Timestamp, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)).ToList();
        //     return sortedDescTagValues;
        // }
        // List<TagValue> sortedAscTagValues = allTagValues.OrderBy(tv => DateTime.ParseExact(tv.Timestamp, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)).ToList();
        // return sortedAscTagValues;
        return _tagRepository.GetAllTagValuesForTag(tagId);
    }

    public ICollection<TagValue> GetAllLastValuesForDigitalInputs(TimeSortReportDTO dto)
    {
        // ICollecti
        return null;
    }

}