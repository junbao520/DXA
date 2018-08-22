using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CarSignalInfo
    {
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RecordTime { get; set; }

        /// <summary>
        /// Gps信息
        /// </summary>
        public GpsInfo Gps { get; set; }

        /// <summary>
        /// 方向角度
        /// </summary>
        public double DirectionDegrees { get; set; }

        /// <summary>
        /// 车载传感器
        /// </summary>
        public CarSensorInfo Sensor { get; set; }

        public ObdCarSensorInfo ObdSensor { get; set; }

        /// <summary>
        /// 车辆运行状态
        /// </summary>
        public CarState CarState { get; set; }

        /// <summary>
        /// 车辆的转向角度（经过计算）
        /// </summary>
        public double BearingAngle { get; set; }

        /// <summary>
        /// 经过计算后的发动机转速
        /// </summary>
        public int EngineRpm { get; set; }

        /// <summary>
        /// 车辆的速度（单位：千米每小时）取车载信号或者gps信号
        /// </summary>
        public double SpeedInKmh { get; set; }

        /// <summary>
        /// 当前行驶距离
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// 考试耗时
        /// </summary>
        public TimeSpan UsedTime { get; set; }

        /// <summary>
        /// 引擎的速率
        /// </summary>
        public int EngineRatio { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get { return IsGpsValid && IsSensorValid; } }

        /// <summary>
        /// Gps是否有效
        /// </summary>
        public bool IsGpsValid { get; set; }

        /// <summary>
        /// 传感器是否有效
        /// </summary>
        public bool IsSensorValid { get; set; }

        #region 陀螺仪新增角度的扩展属性

        /// <summary>
        /// 角度
        /// </summary>
        public double AngleX { get; set; }
        public double AngleY { get; set; }
        public double AngleZ { get; set; }

        /// <summary>
        /// 角速度
        /// </summary>
        public double AngleSpeedX { get; set; }
        public double AngleSpeedY { get; set; }
        public double AngleSpeedZ { get; set; }

        /// <summary>
        /// 角加速度
        /// </summary>
        public double AccelerationX { get; set; }
        public double AccelerationY { get; set; }
        public double AccelerationZ { get; set; }

        #endregion

        public CarSignalInfo()
        {
            RecordTime = DateTime.Now;
        }
        /// <summary>
        /// 破线板信号
        /// </summary>
        public string SensorBody { get; set; }

        /// <summary>
        /// 免破线信号
        /// </summary>
        public string OBDSensorBody { get; set; }

        /// <summary>
        /// 陀螺仪信号
        /// </summary>
        public string GyroSensorBody { get; set; }

        /// <summary>
        /// 传感器信号数组
        /// </summary>
        public int[] inputs { get; set; }

        /// <summary>
        /// 底层原始信号
        /// </summary>
        public string[] commands { get; set; }


    }
    public sealed class GpsInfo
    {
        /// <summary>
        /// Gps时间
        /// </summary>
        public DateTime UtcTime { get; set; }
        /// <summary>
        /// GPS转换后的本地时间
        /// </summary>
        public DateTime LocalTime { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double LatitudeDegrees { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double LongitudeDegrees { get; set; }
        /// <summary>
        /// 正北方向的距离
        /// </summary>
        public double NorthingMeters { get; set; }
        /// <summary>
        /// 正东方向的距离
        /// </summary>
        public double EastingMeters { get; set; }
        /// <summary>
        /// 与正北方向夹角
        /// </summary>
        public double AngleDegrees { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public double SpeedInKmh { get; set; }
        /// <summary>
        /// 俯仰角
        /// </summary>
        public double ElevationDegrees { get; set; }
        /// <summary>
        /// 海拔高度
        /// </summary>
        public double AltitudeMeters { get; set; }
        /// <summary>
        /// Gps精度
        /// </summary>
        public Quality FixQuality { get; set; }
        /// <summary>
        /// The Fixed Satellite Count
        /// </summary>
        public int FixedSatelliteCount { get; set; }
        /// <summary>
        /// The Tracked Satellite Count
        /// </summary>
        public int TrackedSatelliteCount { get; set; }

        public DateTime RecordTime { get; set; }
        /// <summary>
        /// 是否高精度版本
        /// </summary>
        public bool HighPrecisionVersion { get; set; }


        public GpsInfo()
        {
            RecordTime = DateTime.Now;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("UtcTime: ").Append(UtcTime)
                .Append("LocalTime:").Append(LocalTime)
                .Append(" Longitude: ").Append(LongitudeDegrees)
                .Append(" Latitude: ").Append(LatitudeDegrees)
                .Append(" Altitude: ").Append(AltitudeMeters)
                .Append(" Speed: ").Append(SpeedInKmh)
                .Append(" Easting: ").Append(EastingMeters)
                .Append(" Northing: ").Append(NorthingMeters)
                .Append(" Angle: ").Append(AngleDegrees)
                .Append(" Quality: ").Append(FixQuality)
                .Append(" Satellite Count: ").Append(FixedSatelliteCount);
            return sb.ToString();
        }
    }

    [Description("Gps精度")]
    public enum Quality : int
    {
        //Invalid = 0,
        //Fix = 1,
        //Differential = 2,
        //Sensitive = 3,

        /// <summary>
        /// Not enough information is available to specify the current fix quality.
        /// </summary>
        [Description("未知")]
        Unknown,
        /// <summary>No fix is currently obtained.</summary>
        [Description("定位")]
        NoFix,
        /// <summary>A fix is currently obtained using GPS satellites only.</summary>
        [Description("GPS定位")]
        GpsFix,
        /// <summary>A fix is obtained using both GPS satellites and DGPS/WAAS ground
        /// stations.  Position error is as low as 0.5-5 meters.</summary>
        [Description("差分精度")]
        DifferentialGpsFix,
        /// <summary>
        /// A PPS or pulse-per-second fix.  PPS signals very accurately indicate the start of a second.
        /// </summary>
        [Description("非高精度")]
        PulsePerSecond,
        /// <summary>
        /// Used for surveying.  A fix is obtained with the assistance of a reference station.  Position error is as low as 1-5 centimeters.
        /// </summary>
        [Description("高精度")]
        FixedRealTimeKinematic,
        /// <summary>
        /// Used for surveying.  A fix is obtained with the assistance of a reference station.  Position error is as low as 20cm to 1 meter.
        /// </summary>
        [Description("浮动精度")]
        FloatRealTimeKinematic,
        /// <summary>
        /// The fix is being estimated.
        /// </summary>
        [Description("非高精度")]
        Estimated,
        /// <summary>
        /// The fix is being input manually.
        /// </summary>
        [Description("非高精度")]
        ManualInput,
        /// <summary>
        /// The fix is being simulated.
        /// </summary>
        [Description("非高精度")]
        Simulated
    }

    public class CarSensorInfo
    {
        public CarSensorInfo()
        {
            this.RecordTime = DateTime.Now;
            this.Heading = -1;
        }

        #region 车载控制信号
        /// <summary>
        /// 离合器；true：踩到底
        /// </summary>
        public bool Clutch { get; set; }

        /// <summary>
        /// 喇叭
        /// </summary>
        public bool Loudspeaker { get; set; }

        /// <summary>
        /// 雨刷
        /// </summary>
        //public bool WindshieldWiper { get; set; }

        /// <summary>
        /// 安全带
        /// </summary>
        public bool SafetyBelt { get; set; }

        /// <summary>
        /// 档位
        /// </summary>
        public Gear Gear { get; set; }

        /// <summary>
        /// 手刹
        /// </summary>
        public bool Handbrake { get; set; }

        /// <summary>
        /// 刹车
        /// </summary>
        public bool Brake { get; set; }

        /// <summary>
        /// 车门
        /// </summary>
        public bool Door { get; set; }

        /// <summary>
        /// 发动机
        /// </summary>
        public bool Engine { get; set; }

        /// <summary>
        /// 外接的发动机线 
        /// </summary>
        public bool SpecialEngine { get; set; }

        /// <summary>
        /// 发动机转速,这个转速未经处理，请用CarSignal类里面的EngineRpm;
        /// </summary>
        public int EngineRpm { get; set; }
        #endregion

        #region 车载灯光
        /// <summary>
        /// 雾灯
        /// </summary>
        public bool FogLight { get; set; }

        /// <summary>
        /// 示廓灯
        /// </summary>
        public bool OutlineLight { get; set; }

        /// <summary>
        /// 原始实时左转向灯信号
        /// </summary>
        public bool OriginalLeftIndicatorLight { get; set; }

        /// <summary>
        /// 左转向指示灯
        /// </summary>
        public bool LeftIndicatorLight { get; set; }


        /// <summary>
        /// 原始实时右转向指示灯
        /// </summary>
        public bool OriginalRightIndicatorLight { get; set; }

        /// <summary>
        /// 右转向指示灯
        /// </summary>
        public bool RightIndicatorLight { get; set; }

        /// <summary>
        /// 警示灯
        /// </summary>
        public bool CautionLight { get; set; }

        /// <summary>
        /// 远光灯
        /// </summary>
        public bool HighBeam { get; set; }

        /// <summary>
        /// 近光灯
        /// </summary>
        public bool LowBeam { get; set; }

        /// <summary>
        /// 倒车灯
        /// </summary>
        public bool ReversingLight { get; set; }

        #endregion

        #region 扩展的属性
        /// <summary>
        /// 扩展的属性-进过车头
        /// </summary>
        public bool ArrivedHeadstock { get; set; }

        /// <summary>
        /// 扩展的属性-进过车尾
        /// </summary>
        public bool ArrivedTailstock { get; set; }

        /// <summary>
        /// 扩展的属性-进过车头2
        /// </summary>
        public bool ArrivedHeadstock2 { get; set; }

        /// <summary>
        /// 扩展的属性-进过车尾2
        /// </summary>
        public bool ArrivedTailstock2 { get; set; }

        /// <summary>
        /// 汽车座椅
        /// </summary>
        public bool Seats { get; set; }

        /// <summary>
        /// 外后视镜
        /// </summary>
        public bool ExteriorMirror { get; set; }

        /// <summary>
        /// 内后视镜
        /// </summary>
        public bool InnerMirror { get; set; }


        /// <summary>
        /// 指纹仪
        /// </summary>
        public bool Fingerprint { get; set; }

        /// <summary>
        /// 是否空挡
        /// </summary>
        public bool IsNeutral { get; set; }



        #region 档位显示信号

        public bool GearDisplayD1 { get; set; }
        public bool GearDisplayD2 { get; set; }
        public bool GearDisplayD3 { get; set; }
        public bool GearDisplayD4 { get; set; }

        #endregion


        #region 拉线信号
        #region 定义拉线地址 

        public bool PullLineD1 { get; set; }

        public bool PullLineD2 { get; set; }

        public bool PullLineD3 { get; set; }


        public bool PullLineD4 { get; set; }

        public bool PullLineD5 { get; set; }

        public bool PullLineD6 { get; set; }


        #endregion
        #endregion

        #endregion

        /// <summary>
        /// 读取的车速
        /// </summary>
        public double SpeedInKmh { get; set; }

        /// <summary>
        /// 航向角
        /// </summary>
        public double Heading { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RecordTime { get; set; }


        /// <summary>
        /// OBD 档位来源
        /// </summary>
        public Gear OBDGear { get; set; }
        /// <summary>
        /// OBD读取的方向盘角度
        /// </summary>
        public double WheelAngle { get; set; }
        public override string ToString()
        {
            ///这段要根据需求进行重写
            StringBuilder sb = new StringBuilder();
            sb
                .AppendFormat("记录时间: {0:yyyy-MM-dd HH:mm:ss.ff}", this.RecordTime)
                .AppendFormat(" 离合器: {0}", this.Clutch)
                .AppendFormat(" 喇叭: {0}", this.Loudspeaker)
                .AppendFormat(" 安全带: {0}", this.SafetyBelt)
                .AppendFormat(" 档位: {0}", this.Gear.ToString())
                .AppendFormat(" 手刹: {0}", this.Handbrake)
                .AppendFormat(" 刹车: {0}", this.Brake)
                .AppendFormat(" 发动机: {0}", this.Engine)
                .AppendFormat(" 发动机转速(RPM): {0}", this.EngineRpm)
                .AppendFormat(" 雾灯: {0}", this.FogLight)
                .AppendFormat(" 示廓灯: {0}", this.OutlineLight)
                .AppendFormat(" 左转向灯: {0}", this.LeftIndicatorLight)
                .AppendFormat(" 右转向灯: {0}", this.RightIndicatorLight)
                .AppendFormat(" 警报灯: {0}", this.CautionLight)
                .AppendFormat(" 远光灯: {0}", this.HighBeam)
                .AppendFormat(" 近光灯: {0}", this.LowBeam)
                .AppendFormat(" 车速(Kmh): {0}", this.SpeedInKmh)
                .AppendFormat(" 方向盘角度: {0}", this.WheelAngle);
            return sb.ToString();
        }
    }

    [Description("档位")]
    public enum Gear : byte
    {
        [Description("空挡")]
        Neutral = 0,

        [Description("一档")]
        One,

        [Description("二档")]
        Two,

        [Description("三档")]
        Three,

        [Description("四档")]
        Four,

        [Description("五档")]
        Five,

        [Description("倒档")]
        Reverse,
    }
    [Description("车辆运动状态")]
    public enum CarState : byte
    {
        [Description("停车")]
        Stop = 0,

        [Description("运动")]
        Moving = 1,
    }
    public class ObdCarSensorInfo
    {
        public bool Clutch { get; set; }
        public bool SafetyBelt { get; set; }
        public bool Door { get; set; }
        public bool Handbrake { get; set; }
        public bool Brake { get; set; }
        public bool Loudspeaker { get; set; }
        public bool Undefined1 { get; set; }
        public bool HighBeam { get; set; }
        public bool LowBeam { get; set; }
        public bool FogLight { get; set; }
        public bool OutlineLight { get; set; }
        public bool CautionLight { get; set; }
        public bool LeftIndicatorLight { get; set; }
        public bool RightIndicatorLight { get; set; }
        public bool Undefined2 { get; set; }
    }
}
