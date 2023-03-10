using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SSY.Products.Typeforms.Dtos.Response
{
    public class AnswerDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("field")]
        public Field Field { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("choices")]
        public ChoiceDto Choices { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("file_url")]
        public string FileUrl { get; set; }
    }

    public class ChoiceDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("labels")]
        public List<string> Labels { get; set; }
    }

    public class DefinitionDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("fields")]
        public List<Field> Fields { get; set; }
    }

    public class Field
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }

        [JsonPropertyName("allow_multiple_selections")]
        public bool? AllowMultipleSelections { get; set; }

        [JsonPropertyName("choices")]
        public List<ChoiceDto> Choices { get; set; }

        [JsonPropertyName("allow_other_choice")]
        public bool? AllowOtherChoice { get; set; }
    }

    public class Field2
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }
    }

    public class FormResponseDto
    {
        [JsonPropertyName("form_id")]
        public string FormId { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("landed_at")]
        public DateTime LandedAt { get; set; }

        [JsonPropertyName("submitted_at")]
        public DateTime SubmittedAt { get; set; }

        [JsonPropertyName("definition")]
        public DefinitionDto Definition { get; set; }

        [JsonPropertyName("answers")]
        public List<AnswerDto> Answers { get; set; }

        [JsonPropertyName("thankyou_screen_ref")]
        public string ThankyouScreenRef { get; set; }
    }

    public class Properties
    {
    }

    public class PayloadDto
    {
        [JsonPropertyName("event_id")]
        public string EventId { get; set; }

        [JsonPropertyName("event_type")]
        public string EventType { get; set; }

        [JsonPropertyName("form_response")]
        public FormResponseDto FormResponse { get; set; }
    }

    public class ResponseDto
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public IEnumerable<AnswerDto> Answer { get; set; }
    }

    public class InfluencerDto
    {
        public List<ResponseDto> Response{ get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
