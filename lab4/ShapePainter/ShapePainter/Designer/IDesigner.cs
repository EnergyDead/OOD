namespace ShapePainter.Designer;

internal interface IDesigner
{
    PictureDraft CreateDraft(List<string> descriptions);
}
