# GpsSection.GpsMode

## Int digit

### ปัจจุบัน
```
0: none
1: single location
2: dual location
```

### แบบใหม่
```
0 : none
1: single location, first is gps mode
2: single location, first is delivery mode
3: single location, first is address mode
11: dual location, first is gps mode, second is gps mode
12: dual location, first is gps mode, second is delivery mode
13: dual location, first is gps mode, second is address mode
21: dual location, first is delivery mode, second is gps mode
22: dual location, first is delivery mode, second is delivery mode
23: dual location, first is delivery mode, second is address mode
31: dual location, first is address mode, second is gps mode
32: dual location, first is address mode, second is delivery mode
33: dual location, first is address mode, second is address mode
111: triple location, first is gps mode, second is gps mode, third is gps mode
...
```

## Bitwise
```
0: none
1: single location, first is gps mode
2: dual location, first is gps mode, second is gps mode
// 3: 1+2 > 2
4: first is delivery mode
// 5: 1+4 > single location, first is delivery mode
// 6: 2+4 > dual location, first is delivery mode
// 7: 1+2+4 > 6
8: second is delivery mode
// 9: 1+8 > 5
// 10: 2+8 > dual location, first is gps mode, second is delivery mode
// 11: 1+2+8 > 10
// 12: 4+8 > 5
// 13: 1+4+8 > 5
// 14: 2+4+8 > dual location, first is delivery mode, second is delivery mode
// 15: 1+2+4+8 > 14
16: first is address mode
32: second is address mode



0: none
1: single location, first is gps mode
2: single location, first is delivery mode
// 3: 1+2 > single location, first is delivery mode
4: single location, first is address mode
// 5: 1+4 > single location, first is address mode
// 6: 2+4 > 5
// 7: 1+2+4 > 5
8: dual location, first is gps mode, second is gps mode
// 9: 1+8 > 8
// 10: 2+8 > dual location, first is delivery mode, second is gps mode
// 11: 1+2+8 > 10
// 12: 4+8 > dual location, first is address mode, second is gps mode
// 13: 1+4+8 > 12
// 14: 2+4+8 > 12
// 15: 1+2+4+8 > 12
16: dual location, first is gps mode, second is delivery mode
// 17: 1+16 > 16
// 18: 2+16 > dual location, first is delivery mode, second is delivery mode
// 19: 1+2+16 > 18
// 20: 4+16 > dual location, first is address mode, second is delivery mode
// 21: 1+4+16 > 20
// 22: 2+4+16 > 20
// 23: 1+2+4+16 > 20
// 24: 8+16 > 16
// 25: 1+8+16 > 16
// 26: 2+8+16 > 18
// 27: 1+2+8+16 > 18
// 28: 4+8+16 > 20
// 29: 1+4+8+16 > 20
// 30: 2+4+8+16 > 20
// 31: 1+2+4+8+16 > 20
32: second is address mode
// 33: 1+32 > dual location, first is gps mode, second is address mode
// 34: 2+32 > dual location, first is delivery mode, second is address mode
// 35: 1+2+32 > 34
// 36: 4+32 > dual location, first is address mode, second is address mode
// 37: 1+4+32 > 36
// 38: 2+4+32 > 36
// 39: 1+2+4+32 > 36
// 40: 8+32 > 32
// 41: 1+8+32 > 32
// 42: 2+8+32 > 34
// 43: 1+2+8+32 > 34
// 44: 4+8+32 > 36
// 45: 1+4+8+32 > 36
// 46: 2+4+8+32 > 36
// 47: 1+2+4+8+32 > 36
// 48: 16+32 > 32
// 49: 1+16+32 > 32
// 50: 2+16+32 > 34
// 51: 1+2+16+32 > 34
// 52: 4+16+32 > 36
// 53: 1+4+16+32 > 36
// 54: 2+4+16+32 > 36
// 55: 1+2+4+16+32 > 36
// 56: 8+16+32 > 32
// 57: 1+8+16+32 > 32
// 58: 2+8+16+32 > 34
// 59: 1+2+8+16+32 > 34
// 60: 4+8+16+32 > 36
// 61: 1+4+8+16+32 > 36
// 62: 2+4+8+16+32 > 36
// 63: 1+2+4+8+16+32 > 36
```
