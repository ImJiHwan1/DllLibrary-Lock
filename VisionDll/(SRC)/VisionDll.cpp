#include "VisionDll.h"
#include <time.h>

bool bvalidation = false;
int checkTimeLimit(int startYear, int startMonth, int starDay, int limitDays)
{
	struct tm user_stime;
	user_stime.tm_year = startYear - 1900;
	user_stime.tm_mon = startMonth - 1;
	user_stime.tm_mday = starDay;
	user_stime.tm_hour = 0;
	user_stime.tm_min = 0;
	user_stime.tm_sec = 0;
	user_stime.tm_isdst = 0;
	time_t tm_st = mktime(&user_stime);
	
	time_t current_time;
	time(&current_time);

	double d_diff = difftime(current_time, tm_st);
	int tm_day = d_diff / (60 * 60 * 24);
	
	if (limitDays <= tm_day) return 0;
	else return(limitDays - tm_day);
}

extern "C" __declspec(dllexport) int EngineInit()
{
	int day = checkTimeLimit(2019, 11, 18, 365);

	if (day == 0) bvalidation = false;
	else bvalidation = true;

	return day;
}

extern "C" __declspec(dllexport) void EngineHistogramEqualization(
	unsigned char* ret, unsigned char* col, int w, int h)
{
	HistogramEqualization(ret, col, w, h);
}