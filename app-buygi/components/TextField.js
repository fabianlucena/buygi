import { useEffect, useState } from 'react';
import { View, Switch } from 'react-native';
import { TextInput } from 'react-native';
import Field from './Field';
import Label from '../components/Label';
import styles from '../libs/styles';

export default function TextField({
  children,
  value,
  onChangeValue,
  nullable = false,
  style,
  inputStyle,
  labelStyle
}) {
  const [isNull, setIsNull] = useState(false);
  const [localValue, setLocalValue] = useState('');

  useEffect(() => {
    if (value) {
      setLocalValue(value);
      setIsNull(false);
    } else {
      setLocalValue(null);
      setIsNull(true);
    }
  }, [value]);

  function setNull(newIsNull) {
    setIsNull(newIsNull);
    fireOnChangeValue(localValue, newIsNull);
  }

  function onChangeTextHandler(newValue) {
    setLocalValue(newValue);
    fireOnChangeValue(newValue, false);
  }

  function fireOnChangeValue(value, isNull) {
    if (!onChangeValue) {
      return;
    }

    if (isNull) {
      onChangeValue(null);
    } else {
      onChangeValue(value);
    }
  }

  return (
    <Field style={style}>
      <View style={styles.sameLine}>
        <Label tyle={labelStyle}>{children}</Label>
        {nullable? (
          <Switch value={!isNull} onValueChange={() => setNull(!isNull)} />
        ): null}
      </View>
      <TextInput
        style={{...styles.input, ...inputStyle}}
        value={localValue ?? ''}
        onChangeText={onChangeTextHandler}
      />
    </Field>
  );
}