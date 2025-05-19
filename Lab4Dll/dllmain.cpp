#include "pch.h"
#include <vector>
#include <Windows.h>

extern "C" {

    __declspec(dllexport) bool is_prime(int n) {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
        for (int i = 3; i * i <= n; i += 2) {
            if (n % i == 0) return false;
        }
        return true;
    }

    __declspec(dllexport) int get_primes_up_to(int limit, int* output_array, int max_count) {
        if (limit < 2 || output_array == nullptr || max_count <= 0) return 0;
        int count = 0;

        for (int num = 2; num <= limit && count < max_count; ++num) {
            if (is_prime(num)) {
                output_array[count++] = num;
            }
        }

        return count;
    }
}

BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved) {
    switch (ul_reason_for_call) {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}
