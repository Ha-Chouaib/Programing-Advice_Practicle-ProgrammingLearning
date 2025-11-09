#pragma once
#include<iostream>
#include "clsDate.h"

using namespace std;

class clsPeriod
{
public:

    Date::clsDate StartDate;
    Date::clsDate EndDate;

    clsPeriod(Date::clsDate StartDate, Date::clsDate EndDate)
    {
        this->StartDate = StartDate;
        this->EndDate = EndDate;
    }

    static bool IsOverlapPeriods(clsPeriod Period1, clsPeriod Period2)
    {

        if (
            Date::clsDate::CompareDates(Period2.EndDate, Period1.StartDate) == Date::clsDate::enCompareDates ::Before
            ||
            Date::clsDate::CompareDates(Period2.StartDate, Period1.EndDate) == Date::clsDate::enCompareDates::After
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

    static bool IsDateWithinPeriod(clsPeriod Period, Date::clsDate Date)
    {
        return (Date::clsDate::CompareDates(Date,Period.StartDate)== Date::clsDate::enCompareDates::After && Date::clsDate::CompareDates(Date,Period.EndDate)==Date::clsDate::enCompareDates::Before);
    }

    static short GetOverlapDays(clsPeriod Period1, clsPeriod Period2)
    {
        if(IsOverlapPeriods(Period1,Period2))
        {   
            if(IsDateWithinPeriod(Period1,Period2.StartDate) && IsDateWithinPeriod(Period1,Period2.EndDate))
            {
                return Date::clsDate::GetDiffereceOfTowDates(Period2.StartDate,Period2.EndDate);
    
            }

            if(IsDateWithinPeriod(Period1,Period2.StartDate) && IsDateWithinPeriod(Period2,Period1.EndDate))
            {
                return Date::clsDate::GetDiffereceOfTowDates(Period2.StartDate,Period1.EndDate);
    
            }else
            {
                return Date::clsDate::GetDiffereceOfTowDates(Period1.StartDate,Period2.EndDate);
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
