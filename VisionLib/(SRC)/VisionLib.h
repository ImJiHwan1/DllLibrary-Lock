template<typename T>
inline T limit(const T& value)
{
	return ((value > 255) ? 255 : ((value < 0) ? 0 : value));
}

unsigned char* GrayImage(unsigned char* col, int w, int h);
void Histogram(int histo[256], unsigned char* gry, int w, int h);
void HistogramEqualization(unsigned char* ret, unsigned char* col, int w,
	int h);