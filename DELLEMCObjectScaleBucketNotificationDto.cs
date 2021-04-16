using System;
using System.Collections.Generic;
using System.Text;

namespace ECSBucketEventNotification
{

    public class DELLEMCS3BucketEvent
    {
        public string eventVersion { get; set; }
        public string eventSource { get; set; }
        public string awsRegion { get; set; }
        public string eventTime { get; set; }
        public string eventName { get; set; }
        public DELLEMCEventIdentity userIdentity { get; set; }
        public DELLEMCEventRequestParameters requestParameters { get; set; }
        public DELLEMCEventResponseElements responseElements { get; set; }
        public DELLEMCEventS3 S3 { get; set; }
    }

    public class DELLEMCS3BucketEventData
    {
        public DELLEMCS3BucketEvent[] Records { get; set; }
    }

    public class DELLEMCEventIdentity
    {
        public string principalId { get; set; }
    }

    public class DELLEMCEventRequestParameters
    {
        public string sourceIPAddress { get; set; }
    }

    public class DELLEMCEventResponseElements
    {
        public string Xamzrequestid { get; set; }
        public string Xamzid2 { get; set; }
        public DELLEMCS3Bucket Bucket { get; set; }
        public DELLEMCS3Object Object { get; set; }
    }

    public class DELLEMCEventS3
    {
        public string S3SchemaVersion { get; set; }
        public string ConfigurationId { get; set; }
        public DELLEMCS3Bucket Bucket { get; set; }
        public DELLEMCS3Object Object { get; set; }
    }

    public class DELLEMCS3Bucket
    {
        public string name { get; set; }
        public DELLEMCEventIdentity ownerIdentity { get; set; }
        public string arn { get; set; }
    }

    public class DELLEMCS3Object
    {
        public string key { get; set; }
        public string size { get; set; }
        public string etag { get; set; }
        public string versionId { get; set; }
        public string sequencer { get; set; }
    }

}
