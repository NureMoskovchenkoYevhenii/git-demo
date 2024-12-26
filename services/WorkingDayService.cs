﻿public class WorkingDayService
{
    private readonly IWorkingDayRepository _workingDayRepository;

    public WorkingDayService(IWorkingDayRepository workingDayRepository)
    {
        _workingDayRepository = workingDayRepository;
    }

    public void AddWorkingDay(WorkingDay workingDay)
    {
        _workingDayRepository.Add(workingDay);
    }

    public IEnumerable<WorkingDay> GetAllWorkingDays()
    {
        return _workingDayRepository.GetAll();
    }

    public WorkingDay GetWorkingDayById(int workingDayId)
    {
        return _workingDayRepository.GetById(workingDayId);
    }

    public void UpdateWorkingDay(int workingDayId, WorkingDay updatedWorkingDay)
    {
        var workingDay = _workingDayRepository.GetById(workingDayId);
        if (workingDay != null)
        {
            workingDay.StartTime = updatedWorkingDay.StartTime;
            workingDay.EndTime = updatedWorkingDay.EndTime;
            workingDay.DayTypeId = updatedWorkingDay.DayTypeId;
            _workingDayRepository.Update(workingDay);
        }
    }

    public void DeleteWorkingDay(int workingDayId)
    {
        _workingDayRepository.Delete(workingDayId);
    }
}
