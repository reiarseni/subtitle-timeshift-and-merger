# Subtitle Timeshift And Merger

A C# Windows Forms application for editing and manipulating SRT subtitle files. This tool allows you to load, adjust timing, and merge subtitle files from different languages.

## Features

- **Load SRT Files**: Import Spanish and English subtitle files
- **Time Adjustment**: Add or subtract time offsets from subtitle timestamps to fix synchronization issues
- **Merge Subtitles**: Combine Spanish and English subtitle tracks into a single file, sorted chronologically
- **Preview Results**: View the modified subtitles within the application
- **Save Modified Files**: Export the adjusted or merged subtitle files

## Use Cases

- Fix out-of-sync subtitles by adjusting the timing
- Create bilingual subtitle files by merging Spanish and English tracks
- Preview subtitle changes before saving

## Requirements

- Windows operating system
- .NET Framework 4.0 or higher
- Microsoft Visual Studio 2010 or higher (for development)

## Dependencies

- System.Windows.Forms
- System.IO
- System.Collections.Generic
- System.Linq
- System.Text

## Installation

1. Clone or download this repository
2. Open the solution file in Visual Studio
3. Build the solution
4. Run the application

## Usage

1. Click "Load Spanish SRT" to import a Spanish subtitle file
2. Click "Load English SRT" to import an English subtitle file (optional, for merging)
3. To adjust timing:
   - Enter the time offset in the format MM:SS,mmm
   - Click "+" to add time or "-" to subtract time
4. To merge subtitles:
   - Load both Spanish and English subtitle files
   - Click "Merge Subtitles"
5. View the result in the preview panel
6. Click "Save" to save the modified subtitles

## Output

Modified subtitle files are saved to `C:\Subtitulos\SALIDA.srt` by default.

## License

This project is licensed under the MIT License.

