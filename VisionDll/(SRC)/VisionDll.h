#include "../(LIBs)/VisionLib.h"
#pragma comment(lib, "./(LIBs)/VisionLib.lib")

#ifdef  __cplusplus
extern "C" {
#endif //  __cplusplus
	__declspec(dllexport) int EngineInit();
	__declspec(dllexport) void EngineHistogramEqualization(
		unsigned char* ret, unsigned char* col, int w, int h);
#ifdef  __cplusplus
}
#endif //  __cplusplus