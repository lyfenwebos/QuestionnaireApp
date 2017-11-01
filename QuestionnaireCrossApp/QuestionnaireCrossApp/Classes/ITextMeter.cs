using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionnaireCrossApp
{
    public interface ITextMeter
    {
        double MeasureTextSize(string text, double width, double fontSize, string fontName = null);
    }
}