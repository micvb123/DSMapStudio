using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public partial class hkaiPhysics2012ShapeVolume : hkaiVolume
    {
        public override uint Signature { get => 1895575872; }
        
        public hkpShape m_shape;
        public Matrix4x4 m_shapeTransform;
        public hkGeometry m_geometry;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            br.ReadUInt64();
            m_shape = des.ReadClassPointer<hkpShape>(br);
            m_shapeTransform = des.ReadTransform(br);
            m_geometry = new hkGeometry();
            m_geometry.Read(des, br);
        }
        
        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteUInt64(0);
            s.WriteClassPointer<hkpShape>(bw, m_shape);
            s.WriteTransform(bw, m_shapeTransform);
            m_geometry.Write(s, bw);
        }
    }
}
