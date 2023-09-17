using System.Collections;
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
        ICollection<TagValue> allTagValues = _tagRepository.GetAllTagValuesForTag(tagId);
        if (dto.TimeSort == TimeSort.Desc)
        {
            return allTagValues.OrderByDescending(tv => tv.Timestamp).ToList();
        }
        return allTagValues.OrderBy(tv => tv.Timestamp).ToList();
    }

    public ICollection<TagValue> GetAllLastValuesForDigitalInputs(TimeSortReportDTO dto)
    {
        ICollection<TagValue> allTagValues = _tagRepository.GetAllTagValues();
        ICollection<DigitalInput> digitalInputs = _tagRepository.GetAllDigitalInputs();
        
        var digitalInputValues = digitalInputs
            .Select(digitalInput => allTagValues
                .Where(tv => tv.TagId == digitalInput.Id)
                .OrderByDescending(tv => tv.Timestamp)
                .FirstOrDefault()
            )
            .ToList();
        
        if (dto.TimeSort == TimeSort.Desc)
        {
            return digitalInputValues.OrderByDescending(tv => tv.Timestamp).ToList();
        }
        return digitalInputValues.OrderBy(tv => tv.Timestamp).ToList();
    }

    public ICollection<TagValue> GetAllLastValuesForAnalogInputs(TimeSortReportDTO dto)
    {
        ICollection<TagValue> allTagValues = _tagRepository.GetAllTagValues();
        ICollection<AnalogInput> analogInputs = _tagRepository.GetAllAnalogInputs();
        
        var analogInputValues = analogInputs
            .Select(analogInput => allTagValues
                .Where(tv => tv.TagId == analogInput.Id)
                .OrderByDescending(tv => tv.Timestamp)
                .FirstOrDefault()
            )
            .ToList();
        
        if (dto.TimeSort == TimeSort.Desc)
        {
            return analogInputValues.OrderByDescending(tv => tv.Timestamp).ToList();
        }
        return analogInputValues.OrderBy(tv => tv.Timestamp).ToList();
    }

    public ICollection<TagValue> GetAllTagValuesInTimeSpan(TimeSortWithTimeSpanDTO dto)
    {
        ICollection<TagValue> tagValuesInSpan = new List<TagValue>();
        foreach (var tagValue in _tagRepository.GetAllTagValues())
        {
            if (tagValue.Timestamp <= dto.UntilTime && tagValue.Timestamp >= dto.FromTime)
            {
                tagValuesInSpan.Add(tagValue);
            }
        }
        if (dto.TimeSort == TimeSort.Desc)
        {
            return tagValuesInSpan.OrderByDescending(tv => tv.Timestamp).ToList();
        }
        return tagValuesInSpan.OrderBy(tv => tv.Timestamp).ToList();
    }

    public ICollection<AlarmActivation> GetAllAlarmsOfPriority(TimeSortAndAlarmPriorityDTO dto)
    {
        ICollection<AlarmActivation> alarmsOfPriority = new List<AlarmActivation>();
        foreach (var alarmAct in _alarmRepository.GetAllAlarmActivations())
        {
            Alarm alarm = _alarmRepository.GetAlarmById(alarmAct.Id);
            if (alarm.Priority == dto.AlarmPriority)
            {
                alarmsOfPriority.Add(alarmAct);
            }
        }
        if (dto.TimeSort == TimeSort.Desc)
        {
            return alarmsOfPriority.OrderByDescending(aa => aa.Timestamp).ToList();
        }
        return alarmsOfPriority.OrderBy(aa => aa.Timestamp).ToList();
    }

    public ICollection<AlarmActivation> GetAllAlarmsInTimespan(TimeSortAndAlarmSortWithTimeSpanDTO dto)
    {
        ICollection<AlarmActivation> alarmActivationsInSpan = new List<AlarmActivation>();
        foreach (var alarmActivation in _alarmRepository.GetAllAlarmActivations())
        {
            if (alarmActivation.Timestamp <= dto.UntilTime && alarmActivation.Timestamp >= dto.FromTime)
            {
                alarmActivationsInSpan.Add(alarmActivation);
            }
        }

        List<AlarmActivation> timeSorted = new List<AlarmActivation>();
        if (dto.TimeSort == TimeSort.Desc)
        {
            timeSorted = alarmActivationsInSpan.OrderByDescending(aa => aa.Timestamp).ToList();
            // return timeSorted;
            if (dto.AlarmSort == AlarmSort.Desc)
            {
                return timeSorted.OrderByDescending(aa => aa.Alarm.Priority).ToList();
            }
            return timeSorted.OrderBy(aa => aa.Alarm.Priority).ToList();
        }
        
        timeSorted = alarmActivationsInSpan.OrderBy(aa => aa.Timestamp).ToList();
        // return timeSorted;
        if (dto.AlarmSort == AlarmSort.Desc)
        {
            return timeSorted.OrderByDescending(aa => aa.Alarm.Priority).ToList();
        }
        return timeSorted.OrderBy(aa => aa.Alarm.Priority).ToList();

    }
}