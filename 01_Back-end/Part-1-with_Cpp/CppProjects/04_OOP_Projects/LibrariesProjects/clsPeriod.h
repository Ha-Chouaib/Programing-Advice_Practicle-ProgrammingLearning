#pragma once
#include<iostream>
#include "clsDate.h"

class clsPeriod
{
public:

    clsDate StartDate;
    clsDate EndDate;

    clsPeriod(clsDate StartDate, clsDate EndDate)
    {
        this->StartDate = StartDate;
        this->EndDate = EndDate;
    }

    static bool IsOverlapPeriods(clsPeriod Period1, clsPeriod Period2)
    {

        if (
            clsDate::CompareDates(Period2.EndDate, Period1.StartDate) == clsDate::enCompareDates ::Before
            ||
            clsDate::CompareDates(Period2.StartDate, Period1.EndDate) == clsDate::enCompareDates::After
            )
            return false;
        else
            return true;

    }
    
    bool IsOverLapWith(clsPeriod Period2)
    {
        return IsOverlapPeriods(*this, Period2);
    }

    void Print()
    {
        cout << "Period Start: ";
        StartDate.print();

        cout << "Period End: ";
        EndDate.print();
    }

    static bool IsDateWithinPeriod(clsPeriod Period, clsDate Date)
    {
        return (clsDate::CompareDates(Date,Period.StartDate)== clsDate::enCompareDates::After && clsDate::CompareDates(Date,Period.EndDate)==clsDate::enCompareDates::Before);
    }

    static short GetOverlapDays(clsPeriod Period1, clsPeriod Period2)
    {
        if(IsOverlapPeriods(Period1,Period2))
        {   
            if(IsDateWithinPeriod(Period1,Period2.StartDate) && IsDateWithinPeriod(Period1,Period2.EndDate))
            {
                return clsDate::GetDiffereceOfTowDates(Period2.StartDate,Period2.EndDate);
    
            }

            if(IsDateWithinPeriod(Period1,Period2.StartDate) && IsDateWithinPeriod(Period2,Period1.EndDate))
            {
                return clsDate::GetDiffereceOfTowDates(Period2.StartDate,Period1.EndDate);
    
            }else
            {
                return clsDate::GetDiffereceOfTowDates(Period1.StartDate,Period2.EndDate);
            }
        }else
        {
            return 0;
        }
    }

    static unsigned short Length(clsPeriod Period,bool IncludingEndDay=false)
    {
        return Period.StartDate.GetDiffereceOfTowDates(Period.EndDate,IncludingEndDay);
    }
    unsigned short Length(bool IncludingEndDay=false)
    {
        return Length(*this, IncludingEndDay);
    }

};
