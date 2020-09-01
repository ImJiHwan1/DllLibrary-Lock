#include "VisionLib.h"
#include <memory.h>

unsigned char* GrayImage(unsigned char *col, int w, int h)
{
	unsigned char* gry = new unsigned char[w * h];
	
	for (int y = 0; y < h; y++) {
		for (int x = 0; x < w; x++) {

			unsigned char  b = col[3 * ((w) * (y)+(x)) + 0];
			unsigned char  g = col[3 * ((w) * (y)+(x)) + 1];
			unsigned char  r = col[3 * ((w) * (y)+(x)) + 2];

			gry[(w) * (y)+(x)] = (unsigned char)(0.2 * r + 0.7 * g + 0.1 * b);
		}
	}

	return gry;
}

void Histogram(int histo[256], unsigned char* gry, int w, int h)
{
	// 히스토그램 계산
	int x, y, i, temp[256] = { 0, };

	for(y=0; y<h; y++)
		for (x = 0; x < w; x++) {
			histo[gry[(w) * (y)+(x)]]++;
		}
}

void HistogramEqualization(unsigned char* ret, unsigned char* col,
	int w, int h)
{
	unsigned char* gry = GrayImage(col, w, h);

	//히스토그램 계산
	int hist[256] = { 0, };
	Histogram(hist, gry, w, h);

	//히스토그램 누적함수 계산
	int cdf[256] = { 0, };
	cdf[0] = hist[0];
	for (int i = 1; i < 256; i++)
		cdf[i] = cdf[i - 1] + hist[i];

	//히스토그램 균등화
	float N = (float)w * h;
	for (int y = 0; y < h; y++) {
		for (int x = 0; x < w; x++) {
			
			unsigned char g = (unsigned char)limit(cdf[gry[(w) * (y)+(x)]] * 255 / N);
			ret[3 * ((w) * (y)+(x)) + 0] = g;
			ret[3 * ((w) * (y)+(x)) + 1] = g;
			ret[3 * ((w) * (y)+(x)) + 2] = g;
		}
	}
	delete[] gry;
}