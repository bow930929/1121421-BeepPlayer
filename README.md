# 簡易電子琴

## 功能說明

| 按鈕 | 音階 | 頻率 (Hz) |
|------|------|-----------|
| btn1 | Do  | 523  |
| btn2 | Re  | 587  |
| btn3 | Mi  | 659  |
| btn4 | Fa  | 698  |
| btn5 | Sol | 784  |
| btn6 | La  | 880  |
| btn7 | Si  | 988  |
| btn8 | Do  | 1046 |

點擊任一按鈕會發出對應音階的聲音，持續 0.3 秒。

---

## 介面配置

 <img width="1451" height="350" alt="image" src="https://github.com/user-attachments/assets/3fe62099-c0ce-401c-9c11-cc42f29d95d9" />

## 注意事項

- 每個按鈕的 `TabIndex` 須依序設定為 0～7，否則音階對應會錯誤
- 需確保電腦喇叭有開啟，否則 `Beep()` 無聲音輸出
