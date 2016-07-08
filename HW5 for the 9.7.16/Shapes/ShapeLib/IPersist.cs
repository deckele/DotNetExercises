using System.Text;

namespace ShapeLib
{
    public interface IPersist
    {
        void Write(StringBuilder sb);
    }
}
