#pragma once
#include<iostream>
#include<vector>
#include "clsString.h"
#include <string>
using namespace std;

namespace Date
{
    class clsDate
    {
        short _Day = 1;
        short _Month = 1;
        short _Year = 1900;
        short _Hour = 0;
        short _Min = 0;
        short _Sec = 0;


    public:
        clsDate()
        {
            time_t t = time(nullptr);

            tm current{};
            localtime_s(&current, &t);

            _Day = current.tm_mday;
            _Month = current.tm_mon + 1;
            _Year = current.tm_year + 1900;
        }
        clsDate(string strDate)
        {
            vector <string> vDate;
            vDate = Str::clsString::Split(strDate, "/");

            _Day = stoi(vDate[0]);
            _Month = stoi(vDate[1]);
            _Year = stoi(vDate[2]);
        }
        clsDate(short Day, short Month, short Year)
        {
            _Day = Day;
            _Month = Month;
            _Year = Year;
        }
        clsDate(short Days, short Year)
        {
            *this = GetDateFromTotalDaysInYear(Days, Year);
        }

        void SetDay(short Day)
        {
            _Day = Day;
        }
        void SetMonth(short Month)
        {
            _Month = Month;
        }
        void SetYear(short Year)
        {
            _Year = Year;
        }

        short Day()
        {
            return _Day;
        }
        short Month()
        {
            return _Month;
        }
        short Year()
        {
            return _Year;
        }

        void print()
        {
            cout << DateToString(*this) << endl;
        }

        static short NumberOfDaysInYear(short Year)
        {
            return IsLeapYear(Year) ? 366 : 365;
        }

        static int NumberOfHoursInYear(short Year)
        {
            return NumberOfDaysInYear(Year) * 24;
        }

        static int NumberOfMinutesInYear(short Year)
        {
            return NumberOfHoursInYear(Year) * 60;
        }

        static int NumberOfSecondsInYear(short Year)
        {
            return NumberOfMinutesInYear(Year) * 60;
        }
        static string Date_Time_ToString(clsDate Date, string DateSeparator = "/", string TimeSeparator = ":")
        {
            string DT = "";
            DT += to_string(Date._Day) + DateSeparator;
            DT += to_string(Date._Month) + DateSeparator;
            DT += to_string(Date._Year);
            DT += " - ";
            DT += to_string(Date._Hour) + TimeSeparator;
            DT += to_string(Date._Min) + TimeSeparator;
            DT += to_string(Date._Sec);
            return DT;
        }

        static clsDate GetCurrentDate_Time()
        {
            clsDate date;

            time_t t = time(nullptr);
            tm current{};

            localtime_s(&current, &t);

            date._Day = current.tm_mday;
            date._Month = current.tm_mon + 1;
            date._Year = current.tm_year + 1900;
            date._Hour = current.tm_hour;
            date._Min = current.tm_min;
            date._Sec = current.tm_sec;

            return date;
        }


        static short NumberOfDaysInMonth(short Year, short Month)
        {
            short DaysOfMonth[12] = { 31,28,31,30,31,30,31,31,30,31,30,31 };
            return ((Month == 2) ? IsLeapYear(Year) ? 29 : 28 : DaysOfMonth[Month - 1]);

        }
        short NumberOfDaysInMonth()
        {
            return NumberOfDaysInMonth(_Year, _Month);
        }


        static short NumberOfHoursInMonth(short Year, short Month)
        {
            return NumberOfDaysInMonth(Year, Month) * 24;
        }
        short NumberOfHoursInMonth()
        {
            return NumberOfHoursInMonth(_Year, _Month);
        }

        static unsigned short NumberOfMinutesInMonth(short Year, short Month)
        {
            return NumberOfHoursInMonth(Year, Month) * 60;
        }
        unsigned short NumberOfMinutesInMonth()
        {
            return NumberOfMinutesInMonth(_Year, _Month);
        }

        static int NumberOfSecondsInMonth(short Year, short Month)
        {
            return NumberOfMinutesInMonth(Year, Month) * 60;
        }
        int NumberOfSecondsInMonth()
        {
            return NumberOfSecondsInMonth(_Year, _Month);
        }

        static short GetDayOrder(short Year, short Month, short Day)
        {
            short A = 0, Y = 0, M = 0, D = 0;
            A = (14 - Month) / 12;
            Y = Year - A;
            M = Month + (12 * A) - 2;

            return (Day + Y + (Y / 4) - (Y / 100) + (Y / 400) + ((31 * M) / 12)) % 7;
        }
        short GetDayOrder()
        {
            return GetDayOrder(_Year, _Month, _Day);
        }
        static short GetDayOrder(clsDate Date)
        {
            return GetDayOrder(Date._Year, Date._Month, Date._Day);
        }

        static string GetDayName(short DayOrder)
        {
            string DayName[7] = { "Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday" };
            return DayName[DayOrder];

        }
        string GetDayName()
        {
            return GetDayName(this->GetDayOrder());
        }

        static string GetMonthName(short MonthNumber)
        {
            string MonthName[12] = { "January","February","March","April","May","June","July","August","september","October","November","December" };
            return MonthName[MonthNumber - 1];
        }
        string GetMonthName()
        {
            return GetMonthName(this->_Month);
        }

        static bool IsLeapYear(short Year)
        {
            return ((Year % 400 == 0) || (Year % 4 == 0 && Year % 100 != 0));

        }
        bool IsLeapYear()
        {
            return IsLeapYear(_Year);
        }

        static void MonthCalender(short Year, short MonthNumber)
        {
            printf("\n\n--------------%s--------------\n\n", GetMonthName(MonthNumber).c_str());
            printf("  Sun  Mon  Tue  Wed  Thu  Fri  Sat\n");

            short i;
            for (i = 0; i < GetDayOrder(Year, MonthNumber, 1); i++)
            {
                printf("     ");
            }
            for (short z = 1; z <= NumberOfDaysInMonth(Year, MonthNumber); z++)
            {
                printf("%5d", z);

                if (++i == 7)
                {
                    i = 0;
                    printf("\n");
                }

            }
            printf("\n------------------------------------\n");
            cout << endl;
        }
        void MonthCalender()
        {
            MonthCalender(_Year, _Month);
        }


        static void YearCalendar(short Year)
        {
            printf("\n\n---------------------------------\n\n");
            printf("        Calendar - %d", Year);
            printf("\n\n---------------------------------\n\n");

            for (short i = 1; i <= 12; i++)
            {
                MonthCalender(Year, i);
            }
        }
        void YearCalendar()
        {
            YearCalendar(_Year);
        }

        static short TotalDaysFromBeginningOfYear(short Year, short Month, short Day)
        {
            short TotDays = 0;
            for (short i = 1; i <= Month - 1; i++)
            {
                TotDays += NumberOfDaysInMonth(Year, i);
            }

            return TotDays += Day;
        }
        short TotalDaysFromBeginningOfYear()
        {
            return TotalDaysFromBeginningOfYear(_Year, _Month, _Day);
        }

        static clsDate GetDateFromTotalDaysInYear(short TotDays, short Year)
        {
            clsDate Date;
            short DaysOfMonth = 0;
            short RemainingDays = TotDays;

            Date._Year = Year;
            Date._Month = 1;

            while (true)
            {
                DaysOfMonth = NumberOfDaysInMonth(Year, Date._Month);
                if (RemainingDays > DaysOfMonth)
                {
                    RemainingDays -= DaysOfMonth;
                    Date._Month++;
                }
                else
                {
                    Date._Day = RemainingDays;
                    break;
                }
            }
            return Date;
        }

        static clsDate AddDaysToDate(short Year, short Month, short Day, short DaysToAdd)
        {
            clsDate Date;
            short RemainingDays = DaysToAdd + TotalDaysFromBeginningOfYear(Year, Month, Day);
            short DaysFoMonth = 0;

            Date._Year = Year;
            Date._Month = 1;
            while (true)
            {
                DaysFoMonth = NumberOfDaysInMonth(Date._Year, Date._Month);

                if (RemainingDays > DaysFoMonth)
                {
                    Date._Month++;
                    RemainingDays -= DaysFoMonth;

                    if (Date._Month > 12)
                    {
                        Date._Year += 1;
                        Date._Month = 1;
                    }
                }
                else
                {
                    Date._Day = RemainingDays;
                    break;
                }
            }
            return Date;
        }
        clsDate AddDaysToDate(short DaysToAdd)
        {
            return  AddDaysToDate(_Year, _Month, _Day, DaysToAdd);
        }

        static bool IsDate1BeforDate2(clsDate Date1, clsDate Date2)
        {
            return (Date1._Day < Date2._Year) ? true : ((Date1._Year == Date2._Year) ? (Date1._Month < Date2._Month ? true : (Date1._Month == Date2._Month ? Date1._Day < Date2._Day : false)) : false);
        }
        bool IsDateBeforDate(clsDate Date)
        {
            return IsDate1BeforDate2(*this, Date);
        }

        static bool IsDate1EqualDate2(clsDate Date1, clsDate Date2)
        {
            return (Date1._Year == Date2._Year && Date1._Month == Date2._Month && Date1._Day == Date2._Day);
        }
        bool IsDateEqualDate(clsDate Date)
        {
            return IsDate1EqualDate2(*this, Date);
        }

        static bool IsDate1AfterDate2(clsDate Date1, clsDate Date2)
        {
            return (!IsDate1BeforDate2(Date1, Date2) && !IsDate1EqualDate2(Date1, Date2));
        }
        bool IsDateAfterDate(clsDate Date)
        {
            return IsDate1AfterDate2(*this, Date);
        }

        enum enCompareDates { Before = -1, Equal = 0, After = 1 };
        static enCompareDates CompareDates(clsDate Date1, clsDate Date2)
        {
            return IsDate1BeforDate2(Date1, Date2) ? enCompareDates::Before : IsDate1EqualDate2(Date1, Date2) ? enCompareDates::Equal : enCompareDates::After;
        }
        enCompareDates CompareDates(clsDate Date)
        {
            return CompareDates(*this, Date);
        }

        static bool IsValidDate(clsDate Date)
        {
            return ((Date._Day <= NumberOfDaysInMonth(Date._Year, Date._Month) && Date._Day > 0) && (Date._Month > 0 && Date._Month <= 12));
        }
        bool IsValidDate()
        {
            return IsValidDate(*this);
        }

        static string DateToString(clsDate Date, string Separator = "/")
        {
            return to_string(Date._Day) + Separator + to_string(Date._Month) + Separator + to_string(Date._Year);
        }
        string DateToString(string Separator = "/")
        {
            return DateToString(*this, Separator);
        }

        static bool IsLastDayInMonth(clsDate Date)
        {
            return (NumberOfDaysInMonth(Date._Year, Date._Month) == Date._Day);
        }
        bool IsLastDayInMonth()
        {
            return IsLastDayInMonth(*this);
        }

        static bool IsLastMonthInYear(short Month)
        {
            return(Month == 12);
        }
        bool IsLastMonthInYear()
        {
            return IsLastMonthInYear(_Month);
        }

        static clsDate PlusOneDay(clsDate Date)
        {
            if (IsLastDayInMonth(Date))
            {
                Date._Day = 1;
                if (IsLastMonthInYear(Date._Month))
                {
                    Date._Month = 1;
                    Date._Year++;
                }
                else
                {
                    Date._Month += 1;
                }
            }
            else
            {
                Date._Day++;
            }
            return Date;
        }
        void PlusOneDay()
        {
            *this = PlusOneDay(*this);
        }

        static clsDate IncreaseDateByXDays(clsDate Date, short HowManyDaysToAdd)
        {
            for (short i = 0; i < HowManyDaysToAdd; i++)
            {
                Date = PlusOneDay(Date);
            }
            return Date;
        }
        void IncreaseDateByXDays(short HowManyDaysToAdd)
        {
            *this = IncreaseDateByXDays(*this, HowManyDaysToAdd);
        }

        static clsDate IncreaseDateByOneWeek(clsDate& Date)
        {
            return IncreaseDateByXDays(Date, 7);
        }
        void IncreaseDateByOneWeek()
        {
            *this = IncreaseDateByOneWeek(*this);
        }

        static clsDate IncreaseDateByXWeeks(clsDate Date, short HowManyWeeksToAdd)
        {
            for (short i = 0; i < HowManyWeeksToAdd; i++)
            {
                Date = IncreaseDateByOneWeek(Date);
            }
            return Date;
        }
        void IncreaseDateByXWeeks(short HowManyWeeksToAdd)
        {
            *this = IncreaseDateByXWeeks(*this, HowManyWeeksToAdd);
        }

        static clsDate IncreaseDateByOneMonth(clsDate Date)
        {
            if (Date._Month == 12)
            {
                Date._Month = 1;
                Date._Year++;
            }
            else
            {
                Date._Month++;
            }

            short DaysInMonth = 0;
            DaysInMonth = NumberOfDaysInMonth(Date._Year, Date._Month);

            if (Date._Day > DaysInMonth)
            {
                Date._Day = DaysInMonth;
            }
            return Date;

        }
        void IncreaseDateByOneMonth()
        {
            *this = IncreaseDateByOneMonth(*this);
        }

        static clsDate IncreaseDateByXMonths(clsDate Date, short HowManyMonthToAdd)
        {
            for (short i = 0; i < HowManyMonthToAdd; i++)
            {
                Date = IncreaseDateByOneMonth(Date);
            }
            return Date;
        }
        void IncreaseDateByXMonths(short HowManyMonthToAdd)
        {
            *this = IncreaseDateByXMonths(*this, HowManyMonthToAdd);
        }

        static clsDate IncreaseDateByOneYear(clsDate Date)
        {
            Date._Year++;
            return Date;
        }
        void IncreaseDateByOneYear()
        {
            *this = IncreaseDateByOneYear(*this);
        }

        static clsDate IncreaseDateByXYears(clsDate Date, short HowManyYearsToAdd)
        {
            for (short i = 0; i < HowManyYearsToAdd; i++)
            {
                Date = IncreaseDateByOneYear(Date);
            }
            return Date;
        }
        void IncreaseDateByXYears(short HowManyYearsToAdd)
        {
            *this = IncreaseDateByXYears(*this, HowManyYearsToAdd);
        }

        static clsDate IncreaseDateByXYearsFaster(clsDate Date, short HowManyYearsToAdd)
        {
            Date._Year += HowManyYearsToAdd;
            return Date;
        }
        void IncreaseDateByXYearsFaster(short HowManyYearsToAdd)
        {
            *this = IncreaseDateByXYearsFaster(*this, HowManyYearsToAdd);
        }

        static clsDate IncreaseDateByOneDecade(clsDate Date)
        {
            Date._Year += 10;
            return Date;
        }
        void IncreaseDateByOneDecade()
        {
            *this = IncreaseDateByOneDecade(*this);
        }

        static clsDate IncreaseDateByXDecades(clsDate Date, short HowManyDecatesToAdd)
        {
            for (short i = 0;i < HowManyDecatesToAdd; i++)
            {
                Date = IncreaseDateByOneDecade(Date);
            }
            return Date;
        }
        void IncreaseDateByXDecades(short HowManyDecatesToAdd)
        {
            *this = IncreaseDateByXDecades(*this, HowManyDecatesToAdd);
        }

        static clsDate IncreaseDateByXDecadesFaster(clsDate Date, short HowManyDecatesToAdd)
        {
            Date._Year += HowManyDecatesToAdd * 10;
            return Date;
        }
        void IncreaseDateByXDecadesFaster(short HowManyDecatesToAdd)
        {
            *this = IncreaseDateByXDecadesFaster(*this, HowManyDecatesToAdd);
        }

        static clsDate IncreaseDateByOneCenturyclstDate(clsDate Date)
        {
            Date._Year += 100;
            return Date;
        }
        void IncreaseDateByOneCenturyclstDate()
        {
            *this = IncreaseDateByOneCenturyclstDate(*this);
        }

        static clsDate IncreaseDateByOneMillennium(clsDate Date)
        {
            Date._Year += 1000;
            return Date;
        }
        void IncreaseDateByOneMillennium()
        {
            *this = IncreaseDateByOneMillennium(*this);
        }


        static clsDate DecreaseDateByOneDay(clsDate Date)
        {
            if (Date._Day == 1)
            {
                if (Date._Month != 1)
                {
                    Date._Month--;
                }
                else
                {
                    Date._Month = 12;
                    Date._Year--;
                }
                Date._Day = NumberOfDaysInMonth(Date._Year, Date._Month);
            }
            else
            {

                Date._Day--;
            }
            return Date;
        }
        void DecreaseDateByOneDay()
        {
            *this = DecreaseDateByOneDay(*this);
        }

        static clsDate DecreaseDateByXDays(clsDate Date, short HowManyDaysToAdd)
        {
            for (short i = 0; i < HowManyDaysToAdd; i++)
            {
                Date = DecreaseDateByOneDay(Date);
            }
            return Date;
        }
        void DecreaseDateByXDays(short HowManyDaysToAdd)
        {
            *this = DecreaseDateByXDays(*this, HowManyDaysToAdd);
        }

        static clsDate DecreaseDateByOneWeek(clsDate Date)
        {
            return DecreaseDateByXDays(Date, 7);
        }
        void DecreaseDateByOneWeek()
        {
            *this = DecreaseDateByOneWeek(*this);
        }

        static clsDate DecreaseDateByXWeeks(clsDate Date, short HowManyWeeksToAdd)
        {
            for (short i = 0; i < HowManyWeeksToAdd; i++)
            {
                Date = DecreaseDateByOneWeek(Date);
            }
            return Date;
        }
        void DecreaseDateByXWeeks(short HowManyWeeksToAdd)
        {
            *this = DecreaseDateByXWeeks(*this, HowManyWeeksToAdd);
        }

        static clsDate DecreaseDateByOneMonth(clsDate Date)
        {
            if (Date._Month == 1)
            {
                Date._Month = 12;
                Date._Year--;
            }
            else
            {
                Date._Month--;
            }

            short DaysInMonth = 0;
            DaysInMonth = NumberOfDaysInMonth(Date._Year, Date._Month);

            if (Date._Day > DaysInMonth)
            {
                Date._Day = DaysInMonth;
            }
            return Date;

        }
        void DecreaseDateByOneMonth()
        {
            *this = DecreaseDateByOneMonth(*this);
        }

        static clsDate DecreaseDateByXMonths(clsDate Date, short HowManyMonthToAdd)
        {
            for (short i = 0; i < HowManyMonthToAdd; i++)
            {
                Date = DecreaseDateByOneMonth(Date);
            }
            return Date;
        }
        void DecreaseDateByXMonths(short HowManyMonthToAdd)
        {
            *this = DecreaseDateByXMonths(*this, HowManyMonthToAdd);
        }

        static clsDate DecreaseDateByOneYear(clsDate Date)
        {
            Date._Year--;
            return Date;
        }
        void DecreaseDateByOneYear()
        {
            *this = DecreaseDateByOneYear(*this);
        }

        static clsDate DecreaseDateByXYears(clsDate Date, short HowManyYearsToAdd)
        {
            for (short i = 0; i < HowManyYearsToAdd; i++)
            {
                Date = DecreaseDateByOneYear(Date);
            }
            return Date;
        }
        void DecreaseDateByXYears(short HowManyYearsToAdd)
        {
            *this = DecreaseDateByXYears(*this, HowManyYearsToAdd);
        }

        static clsDate DecreaseDateByXYearsFaster(clsDate Date, short HowManyYearsToAdd)
        {
            Date._Year -= HowManyYearsToAdd;
            return Date;
        }
        void DecreaseDateByXYearsFaster(short HowManyYearsToAdd)
        {
            *this = DecreaseDateByXYearsFaster(*this, HowManyYearsToAdd);
        }

        static clsDate DecreaseDateByOneDecade(clsDate Date)
        {
            Date._Year -= 10;
            return Date;
        }
        void DecreaseDateByOneDecade()
        {
            *this = DecreaseDateByOneDecade(*this);
        }

        static clsDate DecreaseDateByXDecades(clsDate Date, short HowManyDecatesToAdd)
        {
            for (short i = 0;i < HowManyDecatesToAdd; i++)
            {
                Date = DecreaseDateByOneDecade(Date);
            }
            return Date;
        }
        void DecreaseDateByXDecades(short HowManyDecatesToAdd)
        {
            *this = DecreaseDateByXDecades(*this, HowManyDecatesToAdd);
        }

        static clsDate DecreaseDateByXDecadesFaster(clsDate Date, short HowManyDecatesToAdd)
        {
            Date._Year -= HowManyDecatesToAdd * 10;
            return Date;
        }
        void DecreaseDateByXDecadesFaster(short HowManyDecatesToAdd)
        {
            *this = DecreaseDateByXDecadesFaster(*this, HowManyDecatesToAdd);
        }

        static clsDate DecreaseDateByOneCentury(clsDate Date)
        {
            Date._Year -= 100;
            return Date;
        }
        void DecreaseDateByOneCentury()
        {
            *this = DecreaseDateByOneCentury(*this);
        }

        static clsDate DecreaseDateByOneMillennium(clsDate Date)
        {
            Date._Year -= 1000;
            return Date;
        }
        void DecreaseDateByOneMillennium()
        {
            *this = DecreaseDateByOneMillennium(*this);
        }

        static bool IsEndOfWeek(short DayOrder)
        {
            return DayOrder == 0;
        }
        bool IsEndOfWeek()
        {
            return IsEndOfWeek(this->GetDayOrder());
        }

        static bool IsWeekEnd(short DayOrder)
        {
            return (DayOrder == 6 || DayOrder == 0);
        }
        bool IsWeekEnd()
        {
            return IsWeekEnd(this->GetDayOrder());
        }

        static bool IsbusinessDay(short DayOrder)
        {
            return (!IsWeekEnd(DayOrder));
        }
        bool IsbusinessDay()
        {
            return  IsbusinessDay(this->GetDayOrder());
        }

        static short DaysUntilTheEndOfWeek(short DayOrder)
        {
            if (DayOrder == 0)
                DayOrder = 7;
            return 7 - DayOrder;
        }
        short DaysUntilTheEndOfWeek()
        {
            return DaysUntilTheEndOfWeek(this->GetDayOrder());
        }

        static short DaysUntilTheEndOfMonth(clsDate Date)
        {
            return NumberOfDaysInMonth(Date._Year, Date._Month) - Date._Day;
        }
        short DaysUntilTheEndOfMonth()
        {
            return  DaysUntilTheEndOfMonth(*this);
        }

        static short DaysUntilTheEndOfYear(clsDate Date)
        {
            return NumberOfDaysInYear(Date._Year) - TotalDaysFromBeginningOfYear(Date._Year, Date._Month, Date._Day);
        }
        short DaysUntilTheEndOfYear()
        {
            return DaysUntilTheEndOfYear(*this);
        }

        static short GetActualVacation(clsDate DateFrom, clsDate DateTo)
        {
            short ActualVac = 0;
            short DayOrder = 0;

            while (IsDate1BeforDate2(DateFrom, DateTo))
            {

                DayOrder = GetDayOrder(DateFrom);
                if (!IsWeekEnd(DayOrder))
                    ActualVac++;
                DateFrom = PlusOneDay(DateFrom);

            }
            return ActualVac;
        }

        static int GetDiffereceOfTowDates(clsDate Date1, clsDate Date2, bool IncludingEndDay = false)
        {
            short TotDaysInDate1 = 0;
            short TotDaysInDate2 = 0;
            short Diff = 0;
            if (IsDate1EqualDate2(Date1, Date2))
            {
                return Diff;
            }
            else
            {

                TotDaysInDate1 = TotalDaysFromBeginningOfYear(Date1._Year, Date1._Month, Date1._Day);
                TotDaysInDate2 = TotalDaysFromBeginningOfYear(Date2._Year, Date2._Month, Date2._Day);
                if (Date1._Year == Date2._Year)
                {
                    Diff = TotDaysInDate1 - TotDaysInDate2;
                }
                else
                {
                    int YearsDiff = Date1._Year - Date2._Year;
                    int NumberOfDaysBetweenYears = 0;
                    if (YearsDiff < 0)
                        YearsDiff *= -1;

                    for (int i = 0; i < YearsDiff; i++)
                    {
                        Date1._Year++;
                        NumberOfDaysBetweenYears += NumberOfDaysInYear(Date1._Year);
                    }


                    Diff = NumberOfDaysBetweenYears + (TotDaysInDate1 - TotDaysInDate2);
                }
            }
            if (Diff < 0)
            {
                Diff *= -1;
            }
            return  IncludingEndDay ? Diff += 1 : Diff;
        }

        int GetDiffereceOfTowDates(clsDate Date, bool IncludingEndDay = false)
        {
            return  GetDiffereceOfTowDates(*this, Date, IncludingEndDay);
        }


    };

}


